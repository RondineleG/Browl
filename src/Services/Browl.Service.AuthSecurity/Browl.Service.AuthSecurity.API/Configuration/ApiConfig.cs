namespace Browl.Service.AuthSecurity.API.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IWebHostEnvironment hostEnvironment)
    {
        _ = services.AddControllers();

        IConfigurationBuilder builder = new ConfigurationBuilder()
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
        if (env.IsDevelopment())
        {
            IApplicationBuilder unused5 = app.UseDeveloperExceptionPage();
        }

        IApplicationBuilder unused4 = app.UseHttpsRedirection();

        IApplicationBuilder unused3 = app.UseRouting();

        IApplicationBuilder unused2 = app.UseIdentityConfiguration();

        IApplicationBuilder unused1 = app.UseEndpoints(endpoints =>
        {
            ControllerActionEndpointConventionBuilder unused = endpoints.MapControllers();
        });

        return app;
    }
}
