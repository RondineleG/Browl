using System.Diagnostics;

using Browl.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Api.Controllers;
public class HomeController : Controller							// HomeController classe, herda Controller
{

	private readonly ILogger<HomeController> _logger;		

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		bool logado = false;

		// Verifica se TempData["Logado"] é nulo antes de acessá-lo
		if (TempData["Logado"] != null)
		{
			bool.TryParse(TempData["Logado"].ToString(), out logado);
		}

		if (!logado)
		{
			return RedirectToAction("Index", "Login");
		}

		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()									// Tratamento de erro
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
