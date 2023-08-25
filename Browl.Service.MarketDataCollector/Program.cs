using Browl.Core.Entities;
using Browl.Core.Interfaces.Services;
using Browl.Data.Services;
using Browl.Service.MarketDataCollector.Configuration;
using Browl.Service.MarketDataCollector.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddApiVersioning(opt =>
    {
        opt.DefaultApiVersion = new
          Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
        opt.AssumeDefaultVersionWhenUnspecified = true;
        opt.ReportApiVersions = true;
        opt.ApiVersionReader = ApiVersionReader.Combine(new
          UrlSegmentApiVersionReader(),
          new HeaderApiVersionReader("x-api-version"),
          new MediaTypeApiVersionReader("x-api-version"));
    });

builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1",
    new OpenApiInfo
    {
        Title = "Browl",
        Version = "v1"
    }
    ));
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.AddTransient<IHabitService, HabitService>();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtTConfiguration(builder.Configuration);
builder.Services.AddFluentValidationConfiguration();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddSwaggerConfiguration();

var ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json")
                         .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
                         .Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Browl V1"));
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseDatabaseConfiguration();
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseRouting();
app.UseJwtConfiguration();
app.MapControllers();
app.Run();