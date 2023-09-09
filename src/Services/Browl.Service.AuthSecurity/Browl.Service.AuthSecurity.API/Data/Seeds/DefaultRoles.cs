using Browl.Service.AuthSecurity.Domain.Constants;

using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Data.Seeds;

public static class DefaultRoles
{
    public static async Task SeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _ = await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        _ = await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        _ = await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
    }
}