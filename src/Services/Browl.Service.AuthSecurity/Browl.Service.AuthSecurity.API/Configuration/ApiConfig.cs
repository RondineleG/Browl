using Browl.Service.AuthSecurity.API.Services;
using Browl.Service.AuthSecurity.API.Services.Interfaces;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class ApiConfig
{
	public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
	{
		_ = services.AddControllers();
		_ = services.AddEndpointsApiExplorer();
		var unused3 = services.AddHttpContextAccessor();

		var unused2 = services.AddScoped<IAuthenticateService, AuthenticateService>();
		var unused1 = services.AddScoped<IUserService, UserService>();

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

		var unused = services.AddCors(options =>
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

		var unused5 = app.UseHttpsRedirection();
		var unused4 = app.UseRouting();
		var unused3 = app.UseAuthentication();
		var unused2 = app.UseAuthorization();
		// app.UseCors("BrowlCors");
		var unused1 = app.UseCors("all");
		var unused = app.UseEndpoints(endpoints =>
		{
			var unused = endpoints.MapControllers();
		});

		return app;
	}
}
