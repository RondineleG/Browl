namespace Browl.Service.AuthSecurity.API.Entities;
public class UserToken
{
	public  string Id { get; set; }
	public  string Email { get; set; }
	public  IEnumerable<UserClaim> UserClaims { get; set; }
}
