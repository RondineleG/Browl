using Browl.Service.MarketDataCollector.Application.Validator;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Text.Json.Serialization;

namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class FluentValidationConfig
{
	[Obsolete]
	public static void AddFluentValidationConfiguration(this IServiceCollection services)
	{
		_ = services.AddControllers()
			.AddNewtonsoftJson(x =>
			{
				x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				x.SerializerSettings.Converters.Add(new StringEnumConverter());
			})
			.AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
			.AddFluentValidation(p =>
		   {
			   _ = p.RegisterValidatorsFromAssemblyContaining<CustomerNewValidator>();
			   _ = p.RegisterValidatorsFromAssemblyContaining<AddressNewValidator>();
			   _ = p.RegisterValidatorsFromAssemblyContaining<CustomerUpdateValidator>();
			   _ = p.RegisterValidatorsFromAssemblyContaining<TelephoneNewValidator>();
			   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
		   });

		_ = services.AddFluentValidationRulesToSwagger();
	}
}