using Browl.Service.AuthSecurity.API.Data;
using Browl.Service.AuthSecurity.Domain.Extensions;
using Browl.Service.AuthSecurity.Domain.Interfaces;
using Browl.Service.AuthSecurity.Domain.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using System.Text;

namespace Browl.Service.AuthSecurity.API.Configuration;

public static class IdentityConfig
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        IServiceCollection unused3 = services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        IdentityBuilder unused2 = services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        // JWT

        IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");
        IServiceCollection unused1 = services.Configure<AppSettings>(appSettingsSection);

        AppSettings? appSettings = appSettingsSection.Get<AppSettings>();
        byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);

        Microsoft.AspNetCore.Authentication.AuthenticationBuilder unused = services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(bearerOptions =>
        {
            bearerOptions.RequireHttpsMetadata = true;
            bearerOptions.SaveToken = true;
            bearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidAudience = appSettings.ValidOn,
                ValidIssuer = appSettings.Issuer
            };
        });

        return services;
    }



    public static IServiceCollection AddJWConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var Key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Key)
            };
        });

        services.AddSingleton<IUserManagerService, UserManagerService>();

        return services;
    }

    public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
    {
        _ = app.UseAuthentication();
        _ = app.UseAuthorization();

        return app;
    }
}
