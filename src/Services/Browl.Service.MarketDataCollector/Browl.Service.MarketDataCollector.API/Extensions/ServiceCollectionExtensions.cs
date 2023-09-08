using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
namespace Browl.Service.MarketDataCollector.API.Extensions;
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddAndMigrateDatabases(this IServiceCollection services, IConfiguration config)
	{
		TenantSettings options = services.GetOptions<TenantSettings>(nameof(TenantSettings));
		string? defaultConnectionString = options.DefaultConnectionString;
		_ = services.AddDbContext<BrowlDbContext>(m => m.UseSqlServer(e => e.MigrationsAssembly(typeof(BrowlDbContext).Assembly.FullName)));
		List<Tenant>? tenants = options.Tenants;
		foreach (Tenant tenant in tenants)
		{
			string? connectionString = string.IsNullOrEmpty(tenant.ConnectionString) ? defaultConnectionString : tenant.ConnectionString;
			using IServiceScope scope = services
			  .BuildServiceProvider().CreateScope();
			BrowlDbContext dbContext = scope.ServiceProvider.GetRequiredService<BrowlDbContext>();
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
		using ServiceProvider serviceProvider = services.BuildServiceProvider();
		IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
		IConfigurationSection section = configuration.GetSection(sectionName);
		T options = new();
		section.Bind(options);
		return options;
	}
}