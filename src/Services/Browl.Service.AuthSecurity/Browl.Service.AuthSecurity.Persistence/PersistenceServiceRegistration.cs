using Browl.Service.AuthSecurity.Application.Contracts.Persistence;
using Browl.Service.AuthSecurity.Persistence.DatabaseContext;
using Browl.Service.AuthSecurity.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Browl.Service.AuthSecurity.Persistence;

public static class PersistenceServiceRegistration
{
	public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
		IConfiguration configuration)
	{
		var unused2 = services.AddDbContext<HrDatabaseContext>(options =>
		{
			var unused1 = options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		});

		var unused = services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

		return services;
	}
}
