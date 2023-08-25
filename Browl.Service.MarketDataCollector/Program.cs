using Browl.Data;
using Browl.Data.Interfaces;
using Browl.Service.MarketDataCollector;
using Browl.Service.MarketDataCollector.Interfaces;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Browl.Service.MarketDataCollector", Version = "v1" }));
builder.Services.AddTransient<ITenantService, TenantService>();
builder.Services.AddTransient<IHabitService, HabitService>();
builder.Services.Configure<TenantSettings>(builder.Configuration.GetSection(nameof(TenantSettings)));
builder.Services.AddAndMigrateDatabases(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Browl.Service.MarketDataCollector V1"));
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();