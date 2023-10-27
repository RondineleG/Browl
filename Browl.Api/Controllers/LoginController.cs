using Browl.Domain.Commands.Login;
using Browl.Domain.IServices;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Api.Controllers;
public class LoginController : Controller
{
	private readonly IAuthenticationService _authenticationService;

	public LoginController(IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}

	public IActionResult Index()
	{
		return View();
	}

	[HttpPost("")]
	public async Task<IActionResult> AuthenticateAsync(AutenticationCommand command)
	{
		var authenticated = await _authenticationService.Authenticate(command);

		if (authenticated == null)
			return BadRequest();

		ViewBag.Logado = true; 

		return RedirectToAction("Index", "Home");

	}
}
