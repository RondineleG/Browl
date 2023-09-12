using Browl.Service.AuthSecurity.API.Configuration;
using Browl.Service.AuthSecurity.API.Data.Seeds;

using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityConfiguration(builder.Configuration);

builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Environment);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

IServiceProvider services = app.Services;
ILoggerFactory loggerFactory = services.GetRequiredService<ILoggerFactory>();
ILogger logger = loggerFactory.CreateLogger("app");
try
{
    using (IServiceScope scope = services.CreateScope())
    {
        IServiceProvider serviceProvider = scope.ServiceProvider;
        UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultUsers.SeedBasicUserAsync(userManager, roleManager);
        await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
        logger.LogInformation("Finished Seeding Default Data");
        logger.LogInformation("Application Starting");
    }

    if (app.Environment.IsDevelopment())
    {

        var unused4 = app.UseSwaggerConfiguration();

        var unused3 = app.UseApiConfiguration(app.Environment);
    }
    var unused2 = app.UseHttpsRedirection();
    var unused1 = app.UseAuthorization();
    ControllerActionEndpointConventionBuilder unused = app.MapControllers();
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

