using Browl.Application.Implementation;
using Browl.Core.Interfaces.Managers;
using Browl.Core.Interfaces.Repositories;
using Browl.Data.Repository;

namespace Browl.Service.MarketDataCollector.Configuration;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IClienteManager, ClienteManager>();
        services.AddScoped<IMedicoRepository, MedicoRepository>();
        services.AddScoped<IMedicoManager, MedicoManager>();
        services.AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioManager, UsuarioManager>();
    }
}