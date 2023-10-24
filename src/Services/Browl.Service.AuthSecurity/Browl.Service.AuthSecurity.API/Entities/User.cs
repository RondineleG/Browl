using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Entities;
public class User : IdentityUser
{
	public int Id { get; set; }

	public  string UserName { get; set; }
	public  string FirstName { get; set; }
	public  string LastName { get; set; }
	public int UserNameChangeLimit { get; set; } = 5;
	public  byte[] ProfilePicture { get; set; }
	public  string Email { get; set; }
	public  string Password { get; set; }
	public  string PasswordConfirmation { get; set; }

}
