namespace Browl.Service.AuthSecurity.API.Entities;
public class UserToken
{
	public required string Id { get; set; }
	public required string Email { get; set; }
	public required IEnumerable<UserClaim> UserClaims { get; set; }
}
