using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.Identity.Entities;

/// <summary>
/// A application user abstraction.
/// </summary>
public class ApplicationUser : IdentityUser
{
	/// <summary>
	/// First name
	/// </summary>
	/// <value cref="string">string</value>
	public required string FirstName { get; set; }
	/// <summary>
	/// Last name
	/// </summary>
	/// <value cref="string">string</value>
	public required string LastName { get; set; }
}
