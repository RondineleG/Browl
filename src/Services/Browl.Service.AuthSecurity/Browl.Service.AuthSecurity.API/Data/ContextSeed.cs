using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Data;

public static class ContextSeed
{
	public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
	{
		//Seed Roles
		_ = await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
		_ = await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
		_ = await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
		_ = await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
	}
	public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
	{
		//Seed Default User
		var defaultUser = new User
		{
			UserName = "rondineleg",
			Email = "superadmin@gmail.com",
			FirstName = "Rondinele",
			LastName = "Guimaraes",
			UserNameChangeLimit = 10,
			EmailConfirmed = true,
			PhoneNumberConfirmed = true
		};
		if (userManager.Users.All(u => u.Id != defaultUser.Id))
		{
			var user = await userManager.FindByEmailAsync(defaultUser.Email);
			if (user == null)
			{
				var unused4 = await userManager.CreateAsync(defaultUser, "123Pa$$word.");
				var unused3 = await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
				var unused2 = await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
				var unused1 = await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
				var unused = await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
			}

		}
	}
}
