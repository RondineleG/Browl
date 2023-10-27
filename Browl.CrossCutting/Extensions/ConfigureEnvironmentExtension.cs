

using Microsoft.Extensions.Configuration;

namespace Browl.CrossCutting.Extensions;
public static class ConfigureEnvironmentExtension
{
	public static void SetEnvironmentConfiguration(this IConfiguration configuration)
	{
		ConnectionStrings.BrowlConnectionString = configuration.GetConnectionString("DatabaseConnection");

		configuration.GetSection("AppConfigutarion").GetChildren().ToList().ForEach(
			config => Environment.SetEnvironmentVariable(config.Key, config.Value)
		);	
	}
}
