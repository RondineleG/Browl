using Browl.Application.Mappings;

namespace Browl.Service.MarketDataCollector.Configuration;

public static class AutoMapperConfig
{
    public static void AddAutoMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(NovoClienteMappingProfile),
            typeof(AlteraClienteMappingProfile),
            typeof(NovoMedicoMappingProfile),
            typeof(UsuarioMappingProfile));
    }
}