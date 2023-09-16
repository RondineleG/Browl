using Browl.Service.AuthSecurity.API.Controllers.Base;
using Browl.Service.AuthSecurity.API.Entities;
using Browl.Service.AuthSecurity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Controllers
{
	[Route("api/identity/[controller]")]
	[ApiController]
	public class UserRolesController : MainController
	{
		private readonly UserManager<User> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public UserRolesController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			var users = await _userManager.Users.ToListAsync();
			var userRolesViewModel = new List<UserRoles>();
			foreach (User user in users)
			{
				var thisViewModel = new UserRoles();
				thisViewModel.UserId = user.Id;
				thisViewModel.Email = user.Email;
				thisViewModel.FirstName = user.FirstName;
				thisViewModel.LastName = user.LastName;
				thisViewModel.Roles = await GetUserRoles(user);
				userRolesViewModel.Add(thisViewModel);
			}
			return Ok(userRolesViewModel);
		}

		[HttpGet("{userId}")]
		public async Task<IActionResult> GetAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return NotFound($"User with Id = {userId} cannot be found");
			}

			var model = new List<ManageUserRoles>();
			foreach (var role in _roleManager.Roles)
			{
				var userRolesViewModel = new ManageUserRoles
				{
					RoleId = role.Id,
					RoleName = role.Name
				};
				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					userRolesViewModel.Selected = true;
				}
				else
				{
					userRolesViewModel.Selected = false;
				}
				model.Add(userRolesViewModel);
			}
			return Ok(model);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(List<ManageUserRoles> model, string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return BadRequest();
			}

			var roles = await _userManager.GetRolesAsync(user);
			var result = await _userManager.RemoveFromRolesAsync(user, roles);
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Cannot remove user existing roles");
				return BadRequest(ModelState);
			}

			result = await _userManager.AddToRolesAsync(user, model.Where(x => x.Selected).Select(y => y.RoleName));
			if (!result.Succeeded)
			{
				ModelState.AddModelError("", "Cannot add selected roles to user");
				return BadRequest(ModelState);
			}

			return Ok();
		}

		private async Task<List<string>> GetUserRoles(User user)
		{
			return new List<string>(await _userManager.GetRolesAsync(user));
		}
	}
}
