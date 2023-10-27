using System.Diagnostics;

using Browl.Api.Models;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Api.Controllers;
public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public HomeController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}

	public IActionResult Index()
	{
		if (ViewBag.Logado == null || ViewBag.Logado == false)
			return RedirectToAction("Index", "Login");
		return View();
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
