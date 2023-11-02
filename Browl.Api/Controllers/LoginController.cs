using Browl.Domain.Commands.Login;
using Browl.Domain.IServices;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Api.Controllers;
public class LoginController : Controller										
{
	private readonly IAuthenticationService _authenticationService;			// Recebe uma injeção de dependências e atribui a uma variavel privada _auth...

	public LoginController(IAuthenticationService authenticationService)
	{
		_authenticationService = authenticationService;
	}

	public IActionResult Index()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> AuthenticateAsync(AutenticationCommand command)
	{
		var authenticated = await _authenticationService.Authenticate(command);

		if (authenticated == null)						// Caso authenticação retorne nulo
			return BadRequest();						

		ViewBag.Logado = true;							// Autenticação aprovada, atribui true em logado

		return RedirectToAction("Index", "Home");		// Redireciona a página

	}
}
