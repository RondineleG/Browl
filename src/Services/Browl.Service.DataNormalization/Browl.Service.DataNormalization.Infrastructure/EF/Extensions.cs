using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Browl.Service.DataNormalization.Application.Services;
using Browl.Service.DataNormalization.Domain.Repositories;
using Browl.Service.DataNormalization.Infrastructure.EF.Contexts;
using Browl.Service.DataNormalization.Infrastructure.EF.Options;
using Browl.Service.DataNormalization.Infrastructure.EF.Repositories;
using Browl.Service.DataNormalization.Infrastructure.EF.Services;
using Browl.Service.DataNormalization.Shared.Options;

namespace Browl.Service.DataNormalization.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, PostgresPackingListRepository>();
            services.AddScoped<IPackingListReadService, PostgresPackingListReadService>();
            
            var options = configuration.GetOptions<PostgresOptions>("Postgres");
            services.AddDbContext<ReadDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx => 
                ctx.UseNpgsql(options.ConnectionString));

            return services;
        }
    }
}