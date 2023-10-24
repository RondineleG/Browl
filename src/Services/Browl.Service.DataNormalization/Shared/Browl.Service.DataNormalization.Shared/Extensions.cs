using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Browl.Service.DataNormalization.Shared.Exceptions;
using Browl.Service.DataNormalization.Shared.Services;

namespace Browl.Service.DataNormalization.Shared
{
    public static class Extensions
    {
        public static IServiceCollection AddShared(this IServiceCollection services)
        {
            services.AddHostedService<AppInitializer>();
            services.AddScoped<ExceptionMiddleware>();
            return services;
        }

        public static IApplicationBuilder UseShared(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            return app;
        }
    }
}