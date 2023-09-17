namespace Browl.Service.AuthSecurity.API.Configuration;

public static class ApiConfig
{
	public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment hostEnvironment, IConfiguration configuration)
	{
		_ = services.AddControllers();
		_ = services.AddEndpointsApiExplorer();

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
		//if (env.IsDevelopment())
		//{
		//	app.UseDeveloperExceptionPage();
		//	app.UseSwagger();
		//	app.UseSwaggerUI(c =>
		//   {
		//	   c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
		//   });
		//}

		var unused5 = app.UseHttpsRedirection();

		var unused4 = app.UseRouting();

		var unused3 = app.UseAuthentication();
		var unused2 = app.UseAuthorization();

		var unused1 = app.UseEndpoints(endpoints =>
		{
			var unused = endpoints.MapControllers();
		});

		return app;
	}
}
