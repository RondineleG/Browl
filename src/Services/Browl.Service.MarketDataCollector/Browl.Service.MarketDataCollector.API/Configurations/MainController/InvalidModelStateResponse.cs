using Browl.Service.MarketDataCollector.API.Extensions;
using Browl.Service.MarketDataCollector.Domain.Resources.Erro;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Configurations.MainController
{
	public static class InvalidModelStateResponse
	{
		public static IActionResult ProduceErrorResponse(ActionContext context)
		{
			List<string> errors = context.ModelState.GetErrorMessages();
			ErrorResource response = new(messages: errors);

			return new BadRequestObjectResult(response);
		}
	}
}