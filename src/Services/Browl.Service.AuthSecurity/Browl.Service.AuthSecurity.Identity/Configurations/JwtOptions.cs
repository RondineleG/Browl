using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.AuthSecurity.Identity.Configurations;

public class JwtOptions
{
	public required string Issuer { get; set; }
	public required string Audience { get; set; }
	public required SigningCredentials SigningCredentials { get; set; }
	public int AccessTokenExpiration { get; set; }
	public int RefreshTokenExpiration { get; set; }
}
