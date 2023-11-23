
using System.Text;

using Browl.CrossCutting.Extensions;
using Browl.Domain.AutoMappper;
using Browl.IoC;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



// APlicando Autenticação JWT
void ConfigureServices(IServiceCollection services)
{
	services.AddCors();
	services.AddControllers();

	var key = Encoding.ASCII.GetBytes(Browl.CrossCutting.Settings.Secret);
	services.AddAuthentication(x =>
	{
		x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	})
	.AddJwtBearer(x =>
	{
		x.RequireHttpsMetadata = false;
		x.SaveToken = true;
		x.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(key),
			ValidateIssuer = false,
			ValidateAudience = false
		};
	});
}
app.Run();
