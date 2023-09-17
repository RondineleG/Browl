using Browl.Service.AuthSecurity.API.Configuration;
using Browl.Service.AuthSecurity.API.Data;
using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Environment, builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseIdentityConfiguration();
app.UseSwaggerConfiguration();

var services = app.Services;
var loggerFactory = services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger("app");
try
{
	var ser = builder.Services;

	using (var scope = services.CreateScope())
	{
		var context = services.GetRequiredService<BrowlAuthSecurityDbContext>();
		var userManager = services.GetRequiredService<UserManager<User>>();
		var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
		await ContextSeed.SeedRolesAsync(userManager, roleManager);
		await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
	}

	if (app.Environment.IsDevelopment())
	{
		logger.LogWarning(app.Environment.EnvironmentName, $"EnvironmentName {app.Environment.EnvironmentName}");
		Console.WriteLine("Is dev");
	}
	app.Run();
}
catch (Exception ex)
{
	logger.LogWarning(ex, "An error occurred seeding the DB");
}
finally
{
	app.Run();
}

