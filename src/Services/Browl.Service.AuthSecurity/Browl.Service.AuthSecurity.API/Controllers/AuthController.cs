using Browl.Service.AuthSecurity.Domain.Entities;
using Browl.Service.AuthSecurity.Domain.Extensions;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Browl.Service.AuthSecurity.API.Controllers;

[Route("api/identity/auth")]
public class AuthController : MainController
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings;

    public AuthController(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager,
                          IOptions<AppSettings> appSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _appSettings = appSettings.Value;
    }

    [HttpPost("new-account")]
    public async Task<ActionResult> Register(User user)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        IdentityUser identityUser = new()
        {
            UserName = user.UserName,
            Email = user.Email,
            EmailConfirmed = true
        };

        IdentityResult result = await _userManager.CreateAsync(identityUser, user.Password);

        if (result.Succeeded)
        {
            return CustomResponse(await GenerateJWT(user.Email));
        }

        foreach (IdentityError error in result.Errors)
        {
            AddErrorProcessing(error.Description);
        }

        return CustomResponse();
    }

    [HttpPost("authenticate")]
    public async Task<ActionResult> Login(UserLogin usuarioLogin)
    {
        if (!ModelState.IsValid)
        {
            return CustomResponse(ModelState);
        }

        Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Password,
            false, true);

        if (result.Succeeded)
        {
            return CustomResponse(await GenerateJWT(usuarioLogin.Email));
        }

        if (result.IsLockedOut)
        {
            AddErrorProcessing("User temporarily blocked for invalid attempts");
            return CustomResponse();
        }

        AddErrorProcessing("Incorrect username or password");
        return CustomResponse();
    }

    private async Task<UserResponse> GenerateJWT(string email)
    {
        IdentityUser? user = await _userManager.FindByEmailAsync(email);
        IList<Claim> claims = await _userManager.GetClaimsAsync(user);

        ClaimsIdentity identityClaims = await GetClaimsUser(claims, user);
        string encodedToken = EncodeToken(identityClaims);

        return GetResponseToken(encodedToken, user, claims);
    }

    private async Task<ClaimsIdentity> GetClaimsUser(ICollection<Claim> claims, IdentityUser user)
    {
        IList<string> userRoles = await _userManager.GetRolesAsync(user);

        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
        foreach (string userRole in userRoles)
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
        byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        SecurityToken token = tokenHandler.CreateToken(new SecurityTokenDescriptor
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
        return new UserResponse
        {
            AccessToken = encodedToken,
            ExpiresIn = TimeSpan.FromHours(_appSettings.ExpirationHours).TotalSeconds,
            UserToken = new UserToken
            {
                Id = user.Id,
                Email = user.Email,
                UserClaims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value })
            }
        };
    }

    private static long ToUnixEpochDate(DateTime date)
    {
        return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
