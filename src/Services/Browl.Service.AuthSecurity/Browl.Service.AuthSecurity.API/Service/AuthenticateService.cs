using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.AuthSecurity.API.Service;

public class AuthenticateService : IAuthenticateService
{

	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly AppSettings _appSettings;

	public AuthenticateService(SignInManager<IdentityUser> signInManager,
						  UserManager<IdentityUser> userManager,
						  IOptions<AppSettings> appSettings)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_appSettings = appSettings.Value;
	}
	public async Task<UserResponse> GenerateJWT(string email)
	{
		var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
		var claims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);
		var identityClaims = await GetClaimsUser(claims, user).ConfigureAwait(false);
		var encodedToken = EncodeToken(identityClaims);
		return GetResponseToken(encodedToken, user, claims);
	}

	private async Task<ClaimsIdentity> GetClaimsUser(ICollection<Claim> claims, IdentityUser user)
	{
		var userRoles = await _userManager.GetRolesAsync(user);
		claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
		claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
		claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
		claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
		claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
		foreach (var userRole in userRoles)
		{
			claims.Add(new Claim("role", userRole));
		}
		ClaimsIdentity identityClaims = new();
		identityClaims.AddClaims(claims);

		return identityClaims;
	}

	private string EncodeToken(ClaimsIdentity identityClaims)
	{
		JwtSecurityTokenHandler tokenHandler = new();
		var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
		var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
		{
			Issuer = _appSettings.Issuer,
			Audience = _appSettings.ValidOn,
			Subject = identityClaims,
			Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		});

		return tokenHandler.WriteToken(token);
	}

	private UserResponse GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
	{
		if (string.IsNullOrEmpty(user?.Email))
		{
			throw new ArgumentException("User email cannot be empty or null.", nameof(user));
		}

		var expiresIn = TimeSpan.FromHours(_appSettings.ExpirationHours).TotalSeconds;
		var userClaims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value }).ToList();

		var response = new UserResponse
		{
			AccessToken = encodedToken,
			ExpiresIn = expiresIn,
			UserToken = new UserToken
			{
				Id = user.Id,
				Email = user.Email,
				UserClaims = userClaims
			}
		};

		return response;
	}


	public long ToUnixEpochDate(DateTime date)
	{
		return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
	}
}
