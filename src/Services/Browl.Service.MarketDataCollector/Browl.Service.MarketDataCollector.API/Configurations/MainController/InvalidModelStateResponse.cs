using Browl.Service.MarketDataCollector.Application.Resources;
using Browl.Service.MarketDataCollector.Domain.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.MarketDataCollector.API.Configurations.MainController
{
    public static class InvalidModelStateResponse
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);

            return new BadRequestObjectResult(response);
        }
    }
}