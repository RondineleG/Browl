namespace Browl.Service.AuthSecurity.Domain.Entities;
public class UserToken
{
	public string Id { get; set; }
	public string Email { get; set; }
	public IEnumerable<UserClaim> UserClaims { get; set; }
}
