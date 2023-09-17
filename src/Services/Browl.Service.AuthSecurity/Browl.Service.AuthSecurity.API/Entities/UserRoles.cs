namespace Browl.Service.AuthSecurity.API.Entities;

public class UserRoles
{
	public required string UserId { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public required string UserName { get; set; }
	public required string Email { get; set; }
	public required IEnumerable<string> Roles { get; set; }
}
