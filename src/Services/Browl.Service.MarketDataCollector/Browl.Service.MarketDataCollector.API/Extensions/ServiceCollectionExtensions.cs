﻿using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Browl.Service.MarketDataCollector.API.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAndMigrateDatabases(this IServiceCollection services, IConfiguration config)
    {
        var options = services.GetOptions<TenantSettings>(nameof(TenantSettings));
        var defaultConnectionString = options.DefaultConnectionString;
        services.AddDbContext<BrowlDbContext>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(BrowlDbContext).Assembly.FullName)));
        var tenants = options.Tenants;
        foreach (var tenant in tenants)
        {
            string connectionString;
            if (string.IsNullOrEmpty(tenant.ConnectionString))
            {
                connectionString = defaultConnectionString;
            }
            else
            {
                connectionString = tenant.ConnectionString;
            }
            using var scope = services
              .BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<BrowlDbContext>();
            dbContext.Database.SetConnectionString(connectionString);
            if (dbContext.Database.GetMigrations().Count() > 0)
            {
                //dbContext.Database.Migrate();
            }
        }
        return services;
    }
    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var section = configuration.GetSection(sectionName);
        var options = new T();
        section.Bind(options);
        return options;
    }
}