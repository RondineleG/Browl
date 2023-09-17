using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Entities;
public class User : IdentityUser
{
	public required string UserName { get; set; }
	public required string FirstName { get; set; }
	public required string LastName { get; set; }
	public int UserNameChangeLimit { get; set; } = 5;
	public required byte[] ProfilePicture { get; set; }
	public required string Email { get; set; }
	public required string Password { get; set; }
	public required string PasswordConfirmation { get; set; }
}
