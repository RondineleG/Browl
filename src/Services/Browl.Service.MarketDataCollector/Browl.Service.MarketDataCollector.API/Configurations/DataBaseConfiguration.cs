using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

using Microsoft.EntityFrameworkCore;
namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class DataBaseConfiguration
{
	public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		_ = services.AddDbContext<BrowlDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection")));
		_ = services.AddDbContext<BrowlDbContext>(options => { _ = options.UseInMemoryDatabase(configuration.GetConnectionString("memory") ?? "data-in-memory"); });
	}

	public static void UseDatabaseConfiguration(this IApplicationBuilder app)
	{
		using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
		using var context = serviceScope.ServiceProvider.GetService<BrowlDbContext>();
	}
}