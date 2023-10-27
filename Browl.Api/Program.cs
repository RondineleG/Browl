
using Browl.CrossCutting.Extensions;
using Browl.Domain.AutoMappper;
using Browl.IoC;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(config => AutoMapperConfiguration.RegisterMappings(config), typeof(Program).Assembly);
builder.Services.RegisterDependencies();

var app = builder.Build();

app.Configuration.SetEnvironmentConfiguration();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
