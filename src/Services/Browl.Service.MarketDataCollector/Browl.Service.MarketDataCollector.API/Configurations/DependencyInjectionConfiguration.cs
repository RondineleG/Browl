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
		services.AddScoped<ITenantService, TenantService>();
		services.AddScoped<IHabitService, HabitService>();
		services.Configure<TenantSettings>(configuration.GetSection(nameof(TenantSettings)));
		services.AddScoped<ICustomerRepository, CustomerRepository>();
		services.AddScoped<ICustomerManager, CustomerService>();
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<IUserManager, UserService>();
		services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
		services.AddControllers().ConfigureApiBehaviorOptions(options =>
		  {
			  options.InvalidModelStateResponseFactory = InvalidModelStateResponse.ProduceErrorResponse;
		  });
		services.AddScoped<ICategoryRepository, CategoryRepository>();
		services.AddScoped<IProductRepository, ProductRepository>();
		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<ICategoryService, CategoryService>();
		services.AddScoped<IProductService, ProductService>();
	}
}
