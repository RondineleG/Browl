using System.Globalization;
using System.Text.Json.Serialization;

using Browl.Service.MarketDataCollector.Application.Validator;

using FluentValidation.AspNetCore;

using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class FluentValidationConfig
{
	[Obsolete]
	public static void AddFluentValidationConfiguration(this IServiceCollection services)
	{
		var unused4 = services.AddControllers()
			.AddNewtonsoftJson(x =>
			{
				x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				x.SerializerSettings.Converters.Add(new StringEnumConverter());
			})
			.AddJsonOptions(p => p.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
			.AddFluentValidation(p =>
		   {
			   var unused3 = p.RegisterValidatorsFromAssemblyContaining<CustomerNewValidator>();
			   var unused2 = p.RegisterValidatorsFromAssemblyContaining<AddressNewValidator>();
			   var unused1 = p.RegisterValidatorsFromAssemblyContaining<CustomerUpdateValidator>();
			   var unused = p.RegisterValidatorsFromAssemblyContaining<TelephoneNewValidator>();
			   p.ValidatorOptions.LanguageManager.Culture = new CultureInfo("pt-BR");
		   });

		_ = services.AddFluentValidationRulesToSwagger();
	}
}
