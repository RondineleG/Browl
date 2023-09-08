using System.Reflection;

using Microsoft.OpenApi.Models;

namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class SwaggerConfiguration
{
	public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
	{
		_ = services.AddSwaggerGen(configuration =>
		{
			configuration.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Browl",
				Version = "v1",
				Description = "API for Market Data Collection",
				Contact = new OpenApiContact
				{
					Name = "Rondinele Guimarães",
					Email = "rondineleg@gmail.com",
					Url = new Uri("https://github.com/rondineleg")
				},
				License = new OpenApiLicense
				{
					Name = "MIT",
					Url = new Uri("https://www.mit.edu/~amini/LICENSE.md")
				},
				TermsOfService = new Uri("https://www.mit.edu/~amini/LICENSE.md")
			});

			var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
			configuration.IncludeXmlComments(xmlPath);

			configuration.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Description = "Token",
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			});

			configuration.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
					new OpenApiSecurityScheme
					{
						Reference= new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id ="Bearer"
						}
					},
						Array.Empty<string>()
					}
			});


		});
		return services;
	}

	public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
	{
		_ = app.UseSwagger().UseSwaggerUI(options =>
		{
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "Browl.Service.MarketDataCollector.API");
			options.DocumentTitle = "Browl.Service.MarketDataCollector.API";
		});
		return app;
	}
}
