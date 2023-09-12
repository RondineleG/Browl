using Browl.Service.AuthSecurity.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.AuthSecurity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRolesController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRolesController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }
    [HttpGet]
    public async Task<List<string>> GetUserRoles(User user)
    {
        return new List<string>(await _userManager.GetRolesAsync(user));
    }
}
