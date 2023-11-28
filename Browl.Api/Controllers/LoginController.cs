using System.ComponentModel.DataAnnotations;

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
		TempData["Logado"] = false;
		if (TempData["LoginAuthenticateError"] != null)
		{
			ViewBag.LoginAuthenticateError = TempData["LoginAuthenticateError"];
			TempData["LoginAuthenticateError"] = null;
		}
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> AuthenticateAsync(AutenticationCommand command)
	{
		try
		{
			var authenticated = await _authenticationService.Authenticate(command);

			if (authenticated == null)
			{
				TempData["LoginAuthenticateError"] = "Usuário ou senha incorretos";
				return RedirectToAction("Index");
			}
			TempData["Logado"] = true;

			return RedirectToAction("Index", "Home");
		}
		catch (Exception ex)
		{
			Console.WriteLine("Erro ao realizar login: " + ex.Message);
			TempData["LoginAuthenticateError"] = "Erro ao realizar login, se o erro persistir entre em contato com o suporte";
			return RedirectToAction("Index");
		}
	}

	public ActionResult Cadastro()
	{
		return View();
	}
}
