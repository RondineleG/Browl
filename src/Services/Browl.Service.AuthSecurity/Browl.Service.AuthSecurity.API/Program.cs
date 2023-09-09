using Browl.Service.AuthSecurity.API.Configuration;
using Browl.Service.AuthSecurity.API.Data.Seeds;

using Microsoft.AspNetCore.Identity;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Environment);
builder.Services.AddSwaggerConfiguration();

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
        // app.UseSwagger();
        //app.UseSwaggerUI();

        IApplicationBuilder unused4 = app.UseSwaggerConfiguration();

        IApplicationBuilder unused3 = app.UseApiConfiguration(app.Environment);
    }
    IApplicationBuilder unused2 = app.UseHttpsRedirection();
    IApplicationBuilder unused1 = app.UseAuthorization();
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

