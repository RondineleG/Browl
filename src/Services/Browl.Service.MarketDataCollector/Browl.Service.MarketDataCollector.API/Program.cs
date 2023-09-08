using Browl.Service.MarketDataCollector.API.Configurations;
using Browl.Service.MarketDataCollector.API.Extensions;
using Microsoft.AspNetCore.Mvc.Versioning;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddJwtTConfiguration(builder.Configuration);
builder.Services.AddFluentValidationConfiguration();
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddMemoryCache();
string? ambiente = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
IConfigurationRoot configuration = new ConfigurationBuilder()
						 .SetBasePath(Directory.GetCurrentDirectory())
						 .AddJsonFile("appsettings.json")
						 .AddJsonFile($"appsettings.{ambiente}.json", optional: true)
						 .Build();
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console());

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
	_ = app.UseDeveloperExceptionPage();
	_ = app.UseSwaggerConfiguration();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseRouting();
app.UseJwtConfiguration();
app.MapControllers();
app.Run();