using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Browl.Service.DataNormalization.Application.Services;
using Browl.Service.DataNormalization.Infrastructure.EF;
using Browl.Service.DataNormalization.Infrastructure.Logging;
using Browl.Service.DataNormalization.Infrastructure.Services;
using Browl.Service.DataNormalization.Shared.Abstractions.Commands;
using Browl.Service.DataNormalization.Shared.Queries;

namespace Browl.Service.DataNormalization.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPostgres(configuration);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            
            return services;
        }
    }
}