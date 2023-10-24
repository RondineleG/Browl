namespace Browl.Service.AuthSecurity.API.Shared.Settings;

public class TokenSettings
{
	public required string SecretKey { get; set; }
	public required string Issuer { get; set; }
	public required string Audience { get; set; }
}
