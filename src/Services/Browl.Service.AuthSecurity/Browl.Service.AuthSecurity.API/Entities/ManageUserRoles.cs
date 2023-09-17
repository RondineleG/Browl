namespace Browl.Service.AuthSecurity.API.Entities;

public class ManageUserRoles
{
	public required string RoleId { get; set; }
	public required string RoleName { get; set; }
	public bool Selected { get; set; }
}
