using Browl.Service.MarketDataCollector.Application.Mappings;

namespace Browl.Service.MarketDataCollector.API.Configurations;

public static class AutoMapperConfiguration
{
	public static void AddAutoMapperConfiguration(this IServiceCollection services)
	{
		_ = services.AddAutoMapper(
			typeof(CustomerNewProfile),
			typeof(CustomerUpdateProfile),
			typeof(UserProfile));
	}
}