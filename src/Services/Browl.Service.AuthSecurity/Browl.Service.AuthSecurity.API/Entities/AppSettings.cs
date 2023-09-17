namespace Browl.Service.AuthSecurity.API.Entities;

public class AppSettings
{
	public required string Secret { get; set; }
	public int ExpirationHours { get; set; }
	public required string Issuer { get; set; }
	public required string ValidOn { get; set; }
}
