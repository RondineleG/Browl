using Browl.Service.AuthSecurity.API.Data;
using Browl.Service.AuthSecurity.Domain.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class ApiConfig
{
	public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
	{
		services.AddControllers();
		services.AddEndpointsApiExplorer();

		IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
			.AddEnvironmentVariables();
				
		if (hostEnvironment.IsDevelopment())
		{
			builder.AddUserSecrets<Program>();
		}

		return services;
	}

	public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
	{
		//if (env.IsDevelopment())
		//{
		//	app.UseDeveloperExceptionPage();
		//	app.UseSwagger();
		//	app.UseSwaggerUI(c =>
		//   {
		//	   c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		//   });
		//}

		app.UseHttpsRedirection();

		app.UseRouting();

		app.UseAuthentication();
		app.UseAuthorization();

		app.UseEndpoints(endpoints =>
		{
			 endpoints.MapControllers();
		});

		return app;
	}
}
