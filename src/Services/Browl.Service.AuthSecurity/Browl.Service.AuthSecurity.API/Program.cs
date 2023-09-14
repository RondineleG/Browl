using Browl.Service.AuthSecurity.API.Configuration;

using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddJWConfiguration(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddApiConfiguration(builder.Environment);
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseApiConfiguration(builder.Environment);
app.UseIdentityConfiguration();
app.UseSwaggerConfiguration();

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
        logger.LogInformation("userManager", userManager);
        logger.LogInformation("roleManager", roleManager);
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

