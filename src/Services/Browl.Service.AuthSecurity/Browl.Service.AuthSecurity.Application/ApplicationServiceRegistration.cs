using System.Reflection;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace Browl.Service.AuthSecurity.Application;

public static class ApplicationServiceRegistration
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		_ = services.AddAutoMapper(Assembly.GetExecutingAssembly());
		_ = services.AddMediatR(Assembly.GetExecutingAssembly());
		return services;
	}
}
