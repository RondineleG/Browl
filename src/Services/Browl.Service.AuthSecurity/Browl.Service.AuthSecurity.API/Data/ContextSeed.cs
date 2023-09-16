using Browl.Service.AuthSecurity.Domain.Entities;

using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Data
{
	public static class ContextSeed
	{
		public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			//Seed Roles
			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Moderator.ToString()));
			await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Basic.ToString()));
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
					await userManager.CreateAsync(defaultUser, "123Pa$$word.");
					await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Basic.ToString());
					await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Moderator.ToString());
					await userManager.AddToRoleAsync(defaultUser, Enums.Roles.Admin.ToString());
					await userManager.AddToRoleAsync(defaultUser, Enums.Roles.SuperAdmin.ToString());
				}

			}
		}
	}
}
