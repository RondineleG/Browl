using Browl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Configuration;

public static class DataBaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BrowlDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ClConnection")));
    }

    public static void UseDatabaseConfiguration(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
        using var context = serviceScope.ServiceProvider.GetService<BrowlDbContext>();
        context.Database.Migrate();
        context.Database.EnsureCreated();
    }
}