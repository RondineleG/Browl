using Browl.Service.MarketDataCollector.Domain.Resources.Erro;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Browl.Service.MarketDataCollector.API.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[ApiController]
public class ErrorController : ControllerBase
{
	[Route("error")]
	public ErrorResponseResource Error()
	{
		Response.StatusCode = 500;
		string? id = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
		return new ErrorResponseResource(id);
	}
}