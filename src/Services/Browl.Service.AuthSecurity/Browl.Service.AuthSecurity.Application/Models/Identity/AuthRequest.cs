namespace Browl.Service.AuthSecurity.Application.Models.Identity;

public class AuthRequest
{
	public required string Email { get; set; }
	public required string Password { get; set; }
}
