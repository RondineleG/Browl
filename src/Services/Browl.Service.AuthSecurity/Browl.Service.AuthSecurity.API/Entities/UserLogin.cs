using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.API.Entities;

public class UserLogin
{
	[Required(ErrorMessage = "Field {0} is mandatory")]
	[EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "Field {0} is mandatory")]
	[StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 6)]
	public required string Password { get; set; }
}
