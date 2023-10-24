using Microsoft.Extensions.DependencyInjection;
using Browl.Service.DataNormalization.Domain.Factories;
using Browl.Service.DataNormalization.Domain.Policies;
using Browl.Service.DataNormalization.Shared;
using Browl.Service.DataNormalization.Shared.Commands;

namespace Browl.Service.DataNormalization.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<IPackingListFactory, PackingListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<IPackingItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
            
            return services;
        }
    }
}