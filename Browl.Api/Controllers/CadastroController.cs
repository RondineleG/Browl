using Browl.MVC.Models;

using Microsoft.AspNetCore.Mvc;

namespace Browl.MVC.Controllers;
public class CadastroController : Controller
{
	[HttpPost]
	public ActionResult Cadastro(string email, string nome, string password)
	{
		if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(password))
		{
			TempData["CadastroAuthenticateError"] = "Todos os campos devem ser preenchidos";
			return RedirectToAction("cadastro", "Login");
		}

		// Lógica para processar o cadastro quando os campos são preenchidos		

		return RedirectToAction("Sucesso"); // Redireciona para uma página de sucesso
	}
}
