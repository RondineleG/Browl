using Browl.Service.AuthSecurity.API.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class DatabaseConfig
{

    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BrowlAuthSecurityDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddIdentity<BrowlAuthSecurityDbContext, IdentityRole>()
                .AddEntityFrameworkStores<BrowlAuthSecurityDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

        return services;
    }
}
