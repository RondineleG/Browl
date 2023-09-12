namespace Browl.Service.AuthSecurity.Domain.Models;

public class ManageUserRolesViewModel
{
    public string UserId { get; set; }
    public IList<UserRolesViewModel> UserRoles { get; set; }
}