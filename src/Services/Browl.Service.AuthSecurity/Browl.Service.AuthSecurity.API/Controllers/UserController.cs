using Browl.Service.AuthSecurity.API.Resources;
using Browl.Service.AuthSecurity.API.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.AuthSecurity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	public UserController(IUserService userService) => _userService = userService;

	[HttpPost("register")]
	public async Task<IActionResult> UserRegistrationAsync(UserRegistrationResources userRegistration)
	{
		var result = await _userService.RegisterNewUserAsync(userRegistration);
		if (result.IsUserRegistered)
		{
			return Ok(result.Message);
		}

		ModelState.AddModelError("Email", result.Message);
		return BadRequest(ModelState);
	}
	[HttpGet("unique-user-email")]
	public IActionResult CheckUniqueUserEmail(string email)
	{
		var result = _userService.CheckUserUniqueEmail(email);
		return Ok(result);
	}
	[HttpPost("login")]
	public async Task<IActionResult> LoginAsync(LoginResource payload)
	{
		var result = await _userService.LoginAsync(payload);
		if (result.IsLoginSuccess)
		{
			return Ok(result.TokeResponse);
		}
		ModelState.AddModelError("LoginError", "Invalid Credentials");
		return BadRequest(ModelState);
	}
}
