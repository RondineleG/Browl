using Browl.Service.AuthSecurity.API.Service;
using Browl.Service.AuthSecurity.API.Services;
using Browl.Service.AuthSecurity.API.Services.Interfaces;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class ApiConfig
{
	public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
	{
		_ = services.AddControllers();
		_ = services.AddEndpointsApiExplorer();
		services.AddHttpContextAccessor();

		services.AddScoped<IAuthenticateService, AuthenticateService>();
		services.AddScoped<IUserService, UserService>();

		// services.AddCors(options =>
		// {
		// 	options.AddPolicy(name: "BrowlCors",
		// 		policy =>
		// 		{
		// 			policy.WithOrigins("https://localhost:7219")
		// 			.AllowAnyHeader()
		// 			.AllowAnyMethod();
		// 		});
		// });

		services.AddCors(options =>
{
	options.AddPolicy("all", builder => builder.AllowAnyOrigin()
	.AllowAnyHeader()
	.AllowAnyMethod());
});


		var builder = new ConfigurationBuilder()
				.SetBasePath(hostEnvironment.ContentRootPath)
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
			.AddEnvironmentVariables();

		if (hostEnvironment.IsDevelopment())
		{
			_ = builder.AddUserSecrets<Program>();
		}

		return services;
	}

	public static IApplicationBuilder UseApiConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
	{

		app.UseHttpsRedirection();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAuthorization();
		// app.UseCors("BrowlCors");
		app.UseCors("all");
		app.UseEndpoints(endpoints =>
		{
			var unused = endpoints.MapControllers();
		});

		return app;
	}
}
