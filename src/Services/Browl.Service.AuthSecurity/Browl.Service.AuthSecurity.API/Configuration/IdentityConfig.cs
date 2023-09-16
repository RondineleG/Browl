using Browl.Service.AuthSecurity.API.Data;
using Browl.Service.AuthSecurity.API.Entities;

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
		services.AddDbContext<BrowlAuthSecurityDbContext>(options =>
			options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
   
		     services.AddDefaultIdentity<IdentityUser>()
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<BrowlAuthSecurityDbContext>()
			.AddDefaultTokenProviders();

		// JWT

		var appSettingsSection = configuration.GetSection("AppSettings");
		services.Configure<AppSettings>(appSettingsSection);

		var appSettings = appSettingsSection.Get<AppSettings>();
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

	public static IApplicationBuilder UseIdentityConfiguration(this IApplicationBuilder app)
	{
		app.UseAuthentication();
		app.UseAuthorization();

		return app;
	}

}
