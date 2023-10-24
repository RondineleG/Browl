namespace Browl.Service.AuthSecurity.Application.Models.Email;

public class EmailSettings
{
	public required string ApiKey { get; set; }
	public required string FromAddress { get; set; }
	public required string FromName { get; set; }
}
