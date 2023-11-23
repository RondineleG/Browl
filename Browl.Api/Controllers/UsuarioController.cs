using Microsoft.AspNetCore.Mvc;

namespace Browl.MVC.Controllers;

public class UsuarioController : Controller
{
	public IActionResult Cadastro()
	{
		return RedirectToAction("cadastro", "Cadastro");
	}
}
