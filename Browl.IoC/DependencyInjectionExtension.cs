using System.Reflection;

using AutoMapper;

using Browl.CrossCutting;
using Browl.Service.Services;
using Browl.Infra.Repositories;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Browl.Infra.Managers;

namespace Browl.IoC;
public static class DependencyInjectionExtension
{
	private const string NAMESPACE = "Browl";
	public static void RegisterDependencies(this IServiceCollection service)
	{
		var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.ManifestModule.Name.Contains(NAMESPACE)).ToList();

		assemblies.Add(typeof(BaseService).Assembly);

		InjectAllServicesAndRepositories(service, assemblies);

		service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		service.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
		service.AddScoped<LoggedUser>();
		service.AddScoped<BrowlConnectionManager>();

	}

	private static void InjectAllServicesAndRepositories(IServiceCollection service, List<Assembly> assemblies)
	{
		var namespaces = new string[]
		{
			"Infra", "Service"
		};

		foreach (var ns in namespaces)
		{
			var nsAssemblies = assemblies.Where(x => x.ManifestModule.Name.EndsWith($"{ns}.dll")).FirstOrDefault();
			foreach (var type in nsAssemblies.ExportedTypes)
			{
				var interfaces = type.GetInterfaces().Where(x => x.Namespace.Contains(NAMESPACE));
				if (type.Name.StartsWith("Base") || interfaces.Count() == 0)
					continue;
				service.AddTransient(interfaces.First(), type);				
			}
		}
	}
}
