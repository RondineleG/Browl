using Browl.Service.MarketDataCollector.Application.Mappings;

namespace Browl.Service.MarketDataCollector.Configuration;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(CustomerNewProfile),
            typeof(CustomerUpdateProfile),
            typeof(UserProfile));
    }
}