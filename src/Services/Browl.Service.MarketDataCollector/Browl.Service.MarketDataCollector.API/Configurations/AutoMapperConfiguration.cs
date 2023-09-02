using Browl.Service.MarketDataCollector.Application.Mappings;

namespace Browl.Service.MarketDataCollector.Configuration;

public static class AutoMapperConfiguration
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(NovoClienteMappingProfile),
            typeof(AlteraClienteMappingProfile),
            typeof(UsuarioMappingProfile));
    }
}