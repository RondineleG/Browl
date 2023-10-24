using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Browl.Service.AuthSecurity.Application.DTOs.User.Request;
using Browl.Service.AuthSecurity.Application.DTOs.User.Response;
using Browl.Service.AuthSecurity.Application.Interfaces.Services;
using Browl.Service.AuthSecurity.Identity.Configurations;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Browl.Service.AuthSecurity.Identity.Services;

public class IdentityService : IIdentityService
{
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly JwtOptions _jwtOptions;

	public IdentityService(SignInManager<IdentityUser> signInManager,
						   UserManager<IdentityUser> userManager,
						   IOptions<JwtOptions> jwtOptions)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_jwtOptions = jwtOptions.Value;
	}

	public async Task<UsuarioCadastroResponse> CadastrarUsuarioAsync(UsuarioCadastroRequest usuarioCadastro)
	{
		var identityUser = new IdentityUser
		{
			UserName = usuarioCadastro.Email,
			Email = usuarioCadastro.Email,
			EmailConfirmed = true
		};

		var result = await _userManager.CreateAsync(identityUser, usuarioCadastro.Senha);
		if (result.Succeeded)
		{
			var unused = await _userManager.SetLockoutEnabledAsync(identityUser, false);
		}

		var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
		if (!result.Succeeded && result.Errors.Count() > 0)
		{
			usuarioCadastroResponse.AdicionarErros(result.Errors.Select(r => r.Description));
		}

		return usuarioCadastroResponse;
	}

	public async Task<UsuarioLoginResponse> LoginAsync(UsuarioLoginRequest usuarioLogin)
	{
		var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
		if (result.Succeeded)
		{
			return await GerarCredenciaisAsync(usuarioLogin.Email);
		}

		var usuarioLoginResponse = new UsuarioLoginResponse();
		if (!result.Succeeded)
		{
			if (result.IsLockedOut)
			{
				usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
			}
			else if (result.IsNotAllowed)
			{
				usuarioLoginResponse.AdicionarErro("Essa conta não tem permissão para fazer login");
			}
			else if (result.RequiresTwoFactor)
			{
				usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu segundo fator de autenticação");
			}
			else
			{
				usuarioLoginResponse.AdicionarErro("Usuário ou senha estão incorretos");
			}
		}

		return usuarioLoginResponse;
	}

	public async Task<UsuarioLoginResponse> LoginSemSenhaAsync(string usuarioId)
	{
		var usuarioLoginResponse = new UsuarioLoginResponse();
		var usuario = await _userManager.FindByIdAsync(usuarioId);

		if (await _userManager.IsLockedOutAsync(usuario))
		{
			usuarioLoginResponse.AdicionarErro("Essa conta está bloqueada");
		}
		else if (!await _userManager.IsEmailConfirmedAsync(usuario))
		{
			usuarioLoginResponse.AdicionarErro("Essa conta precisa confirmar seu e-mail antes de realizar o login");
		}

		return usuarioLoginResponse.Sucesso ? await GerarCredenciaisAsync(usuario.Email) : usuarioLoginResponse;
	}

	private async Task<UsuarioLoginResponse> GerarCredenciaisAsync(string email)
	{
		var user = await _userManager.FindByEmailAsync(email);
		var accessTokenClaims = await ObterClaimsAsync(user, adicionarClaimsUsuario: true);
		var refreshTokenClaims = await ObterClaimsAsync(user, adicionarClaimsUsuario: false);

		var dataExpiracaoAccessToken = DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration);
		var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtOptions.RefreshTokenExpiration);

		var accessToken = GerarToken(accessTokenClaims, dataExpiracaoAccessToken);
		var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

		return new UsuarioLoginResponse
		(
			sucesso: true,
			accessToken: accessToken,
			refreshToken: refreshToken
		);
	}

	private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
	{
		var jwt = new JwtSecurityToken(
			issuer: _jwtOptions.Issuer,
			audience: _jwtOptions.Audience,
			claims: claims,
			notBefore: DateTime.Now,
			expires: dataExpiracao,
			signingCredentials: _jwtOptions.SigningCredentials);

		return new JwtSecurityTokenHandler().WriteToken(jwt);
	}

	private async Task<IList<Claim>> ObterClaimsAsync(IdentityUser user, bool adicionarClaimsUsuario)
	{
		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Id),
			new Claim(JwtRegisteredClaimNames.Email, user.Email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()),
			new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString())
		};

		if (adicionarClaimsUsuario)
		{
			var userClaims = await _userManager.GetClaimsAsync(user);
			var roles = await _userManager.GetRolesAsync(user);

			claims.AddRange(userClaims);

			foreach (var role in roles)
			{
				claims.Add(new Claim("role", role));
			}
		}

		return claims;
	}
}
