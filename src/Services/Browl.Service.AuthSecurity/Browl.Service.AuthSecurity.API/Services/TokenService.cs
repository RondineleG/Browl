using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Browl.Service.AuthSecurity.API.Entities.Members;

using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.AuthSecurity.API.Services;

public class TokenService
{
	private const int ExpirationMinutes = 30;
	public string CreateToken(Member user)
	{
		var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
		var token = CreateJwtToken(
			CreateClaims(user),
			CreateSigningCredentials(), //test
			expiration
		);
		var tokenHandler = new JwtSecurityTokenHandler();
		return tokenHandler.WriteToken(token);
	}

	private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
		DateTime expiration) =>
		new(
			"apiWithAuthBackend",
			"apiWithAuthBackend",
			claims,
			expires: expiration,
			signingCredentials: credentials
		);

	private List<Claim> CreateClaims(Member user)
	{
		try
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Email, user.Email)
			};
			return claims;
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
	private SigningCredentials CreateSigningCredentials() => new(
			new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes("this is my custom Secret key for authentication")
			),
			SecurityAlgorithms.HmacSha256
		);
}
