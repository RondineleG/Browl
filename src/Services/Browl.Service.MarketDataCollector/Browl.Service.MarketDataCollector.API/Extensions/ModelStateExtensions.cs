using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Browl.Service.MarketDataCollector.API.Extensions;

public static class ModelStateExtensions
{
	public static List<string> GetErrorMessages(this ModelStateDictionary dictionary) => dictionary.SelectMany(m => m.Value!.Errors).Select(m => m.ErrorMessage).ToList();
}