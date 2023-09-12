using Browl.Service.AuthSecurity.Domain.Constants;
using Browl.Service.AuthSecurity.Domain.Enums;

using Microsoft.AspNetCore.Identity;

using System.Security.Claims;

namespace Browl.Service.AuthSecurity.API.Data.Seeds;

public static class DefaultUsers
{
    public static async Task SeedBasicUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        IdentityUser defaultUser = new()
        {
            UserName = "basicuser@gmail.com",
            Email = "basicuser@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            IdentityUser? user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                IdentityResult unused1 = await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                IdentityResult unused = await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
            }
        }
    }

    public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        IdentityUser defaultUser = new()
        {
            UserName = "superadmin@gmail.com",
            Email = "superadmin@gmail.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            IdentityUser? user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                IdentityResult unused3 = await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                IdentityResult unused2 = await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                IdentityResult unused1 = await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                IdentityResult unused = await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }
            await roleManager.SeedClaimsForSuperAdmin();
        }
    }

    private static async Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
    {
        IdentityRole? adminRole = await roleManager.FindByNameAsync("SuperAdmin");
        await roleManager.AddPermissionClaim(adminRole, "Products");
    }

    public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
    {
        IList<Claim> allClaims = await roleManager.GetClaimsAsync(role);
        List<string> allPermissions = Permissions.GeneratePermissionsForModule(module);
        foreach (string permission in allPermissions)
        {
            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
            {
                IdentityResult unused = await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
            }
        }
    }
}
