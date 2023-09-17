using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Browl.Service.AuthSecurity.API.Controllers.Base;
using Browl.Service.AuthSecurity.API.Entities;
using Browl.Service.AuthSecurity.API.Services.Interfaces;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.AuthSecurity.API.Controllers;


[Route("api/identity/auth")]
public class AuthController : MainController
{
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly AppSettings _appSettings;
	private readonly IAuthenticateService _authenticateService;
	public AuthController(SignInManager<IdentityUser> signInManager,
						  UserManager<IdentityUser> userManager,
						  IOptions<AppSettings> appSettings,
						  IAuthenticateService authenticateService)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_appSettings = appSettings.Value;
		_authenticateService = authenticateService;
	}

	[HttpPost("new-account")]
	public async Task<ActionResult> Register(UserRegister userRegister)
	{
		if (!ModelState.IsValid)
		{
			return CustomResponse(ModelState);
		}

		var identityUser = new User
		{
			UserName = userRegister.UserName,
			FirstName = userRegister.FirstName,
			LastName = userRegister.LastName,
			UserNameChangeLimit = userRegister.UserNameChangeLimit,
			ProfilePicture = userRegister.ProfilePicture,
			Email = userRegister.Email,
			EmailConfirmed = true,
			Password = userRegister.Password,
			PasswordConfirmation = userRegister.PasswordConfirmation
		};

		var result = await _userManager.CreateAsync(identityUser, userRegister.Password);

		if (result.Succeeded)
		{
			return CustomResponse(await _authenticateService.GenerateJWT(userRegister.Email));
		}

		foreach (var error in result.Errors)
		{
			AddErrorProcessing(error.Description);
		}

		return CustomResponse();
	}

	
	[HttpPost("authenticate")]
	public async Task<ActionResult> Login(UserLogin usuarioLogin)
	{
		if (!ModelState.IsValid)
		{
			return CustomResponse(ModelState);
		}

		var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Password,
			false, true);

		if (result.Succeeded)
		{
			return CustomResponse(await _authenticateService.GenerateJWT(usuarioLogin.Email));
		}

		if (result.IsLockedOut)
		{
			AddErrorProcessing("User temporarily blocked for invalid attempts");
			return CustomResponse();
		}

		AddErrorProcessing("Incorrect username or password");
		return CustomResponse();
	}
		
}
