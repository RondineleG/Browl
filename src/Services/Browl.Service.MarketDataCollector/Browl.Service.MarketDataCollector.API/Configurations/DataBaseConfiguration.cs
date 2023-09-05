using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Browl.Service.MarketDataCollector.Configuration;

public static class DataBaseConfiguration
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BrowlDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SQLConnection")));
        services.AddDbContext<BrowlDbContext>(options => { options.UseInMemoryDatabase(configuration.GetConnectionString("memory") ?? "data-in-memory"); });
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<BrowlDbContext>();
    }
}