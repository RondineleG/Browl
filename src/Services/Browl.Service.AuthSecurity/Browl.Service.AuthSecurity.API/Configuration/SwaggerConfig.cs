using Microsoft.OpenApi.Models;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        IServiceCollection unused = services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Browl Service AuthSecurity API",
                Description = "This API guarantees the security and proper authentication of users in the application.",
                Contact = new OpenApiContact() { Name = "Rondinele Guimarães", Email = "dev@cia3r.com.br" },
                License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
            });

        });

        return services;
    }

	public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		});

		return app;
	}
}
