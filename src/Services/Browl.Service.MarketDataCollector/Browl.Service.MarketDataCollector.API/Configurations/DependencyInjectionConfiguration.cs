using Browl.Service.MarketDataCollector.API.Configurations.MainController;
using Browl.Service.MarketDataCollector.Application.Implementation;
using Browl.Service.MarketDataCollector.Application.Services;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class DependencyInjectionConfiguration
{
	public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		_ = services.AddScoped<ITenantService, TenantService>();
		_ = services.AddScoped<IHabitService, HabitService>();
		_ = services.Configure<TenantSettings>(configuration.GetSection(nameof(TenantSettings)));
		_ = services.AddScoped<ICustomerRepository, CustomerRepository>();
		_ = services.AddScoped<ICustomerManager, CustomerManager>();
		_ = services.AddScoped<IUserRepository, UserRepository>();
		_ = services.AddScoped<IUserManager, UserManager>();
		_ = services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
		_ = services.AddControllers().ConfigureApiBehaviorOptions(options =>
		  {
			  options.InvalidModelStateResponseFactory = InvalidModelStateResponse.ProduceErrorResponse;
		  });
		_ = services.AddScoped<ICategoryRepository, CategoryRepository>();
		_ = services.AddScoped<IProductRepository, ProductRepository>();
		_ = services.AddScoped<IUnitOfWork, UnitOfWork>();
		_ = services.AddScoped<ICategoryService, CategoryService>();
		_ = services.AddScoped<IProductService, ProductService>();
	}
}