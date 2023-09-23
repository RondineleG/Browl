using Browl.Service.AuthSecurity.API.Configuration;
using Browl.Service.AuthSecurity.API.Data;
using Browl.Service.AuthSecurity.API.Entities;
using Browl.Service.AuthSecurity.API.Middleware;
using Browl.Service.AuthSecurity.Application;
using Browl.Service.AuthSecurity.Identity;
using Browl.Service.AuthSecurity.Infrastructure;
using Browl.Service.AuthSecurity.Persistence;

using Microsoft.AspNetCore.Identity;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig
	.WriteTo.Console()
	.ReadFrom.Configuration(context.Configuration));

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Environment, builder.Configuration);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();


app.UseIdentityConfiguration();
app.UseSwaggerConfiguration();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

//app.UseHttpsRedirection();

//app.UseCors("all");

//app.UseAuthentication();
//app.UseAuthorization();

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

