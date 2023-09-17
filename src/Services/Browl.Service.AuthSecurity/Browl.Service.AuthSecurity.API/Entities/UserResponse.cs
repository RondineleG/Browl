namespace Browl.Service.AuthSecurity.API.Entities;
public class UserResponse
{
	public required string AccessToken { get; set; }
	public double ExpiresIn { get; set; }
	public required UserToken UserToken { get; set; }
}
