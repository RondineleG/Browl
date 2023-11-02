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

	public IActionResult Index()									// Método para lidar com a rota padrão quando o usuário acessa
	{
		if (ViewBag.Logado == null || ViewBag.Logado == false)		// Verifica se a view.Bag é nula ou falsa
			return RedirectToAction("Index", "Login");				
		return View();												// Caso View.bag.logado não seja nula ou falsa, retorna View
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
