﻿using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.Domain.Entities;
public class User
{
	[Required(ErrorMessage = "Field {0} is mandatory")]
	[EmailAddress(ErrorMessage = "Field {0} is in an invalid format")]
	public string Email { get; set; }

	[Required(ErrorMessage = "Field {0} is mandatory")]
	[StringLength(100, ErrorMessage = "Field {0} must be between {2} and {1} characters", MinimumLength = 6)]
	public string Password { get; set; }

	[Compare("Password", ErrorMessage = "Passwords don't match.")]
	public string PasswordConfirmation { get; set; }
	public string UserName { get; set; }
}
