using Browl.Service.AuthSecurity.Domain.Entities;
using Browl.Service.AuthSecurity.Domain.Enums;

using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Data.Seeds;

public static class ContextSeed
{
    public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Roles
        await roleManager.CreateAsync(new IdentityRole(Roles.SuperAdmin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
        await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
    }
    public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        //Seed Default User
        var defaultUser = new User
        {
            UserName = "superadmin",
            Email = "superadmin@gmail.com",
            FirstName = "Rondinele",
            LastName = "Guimarães",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };
        if (userManager.Users.All(u => u.Id != defaultUser.Id))
        {
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(defaultUser, "123Pa$$word.");
                await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
            }

        }
    }
}