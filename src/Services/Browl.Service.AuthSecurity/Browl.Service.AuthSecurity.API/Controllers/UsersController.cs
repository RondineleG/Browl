using Browl.Service.AuthSecurity.Domain.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Route("api/identity/auth")]
    public class UsersController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet("list-roles")]
        public async Task<IActionResult> GetRoles()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return Json(roles);
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            if (roleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole(roleName.Trim()));
            }
            return Json(new { success = true });
        }

        [HttpGet("list-account-users")]
        public async Task<IActionResult> GetUsers()
        {
            IdentityUser? currentUser = await _userManager.GetUserAsync(HttpContext.User);
            List<IdentityUser> allUsersExceptCurrentUser = await _userManager.Users.Where(a => a.Id != currentUser.Id).ToListAsync();
            return Json(allUsersExceptCurrentUser);
        }

        [HttpGet("list-account-users/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
        {
            List<UserRolesViewModel> viewModel = new();
            IdentityUser? user = await _userManager.FindByIdAsync(userId);
            foreach (IdentityRole? role in _roleManager.Roles.ToList())
            {
                UserRolesViewModel userRolesViewModel = new()
                {
                    RoleName = role.Name,
                    Selected = await _userManager.IsInRoleAsync(user, role.Name)
                };
                viewModel.Add(userRolesViewModel);
            }
            ManageUserRolesViewModel model = new()
            {
                UserId = userId,
                UserRoles = viewModel
            };

            return Json(model);
        }

        [HttpPost("update-account")]
        public async Task<IActionResult> UpdateUserRoles(string id, ManageUserRolesViewModel model)
        {
            IdentityUser? user = await _userManager.FindByIdAsync(id);
            IList<string> roles = await _userManager.GetRolesAsync(user);
            IdentityResult result = await _userManager.RemoveFromRolesAsync(user, roles);
            result = await _userManager.AddToRolesAsync(user, model.UserRoles.Where(x => x.Selected).Select(y => y.RoleName));
            IdentityUser? currentUser = await _userManager.GetUserAsync(User);
            await _signInManager.RefreshSignInAsync(currentUser);
            await Data.Seeds.DefaultUsers.SeedSuperAdminAsync(_userManager, _roleManager);
            return Json(new { userId = id });
        }
    }
}