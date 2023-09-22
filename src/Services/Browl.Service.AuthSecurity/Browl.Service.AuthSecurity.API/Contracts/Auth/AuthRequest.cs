namespace Browl.Service.AuthSecurity.API.Contracts.Auth;

public class AuthRequest
{
	public string Email { get; set; } = null!;
	public string Password { get; set; } = null!;
}
