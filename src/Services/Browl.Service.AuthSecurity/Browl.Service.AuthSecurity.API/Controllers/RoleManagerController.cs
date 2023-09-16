using Browl.Service.AuthSecurity.API.Controllers.Base;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Controllers
{
	[Route("api/identity/[controller]")]
	[ApiController]
	public class RoleManagerController : MainController
	{
		private readonly RoleManager<IdentityRole> _roleManager;

		public RoleManagerController(RoleManager<IdentityRole> roleManager)
		{
			_roleManager = roleManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return Ok(roles);
		}

		[HttpPost]
		public async Task<IActionResult> PostAsync(string roleName)
		{
			if (roleName != null)
			{
				await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
				return Ok();
			}
			else
			{
				return BadRequest("Role name cannot be null.");
			}
		}
	}
}
