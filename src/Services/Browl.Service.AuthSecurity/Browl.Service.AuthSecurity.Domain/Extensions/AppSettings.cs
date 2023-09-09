namespace Browl.Service.AuthSecurity.Domain.Extensions
{
	public class AppSettings
	{
		public string Secret { get; set; }
		public int ExpirationHours { get; set; }
		public string Issuer { get; set; }
		public string ValidOn { get; set; }
	}
}
