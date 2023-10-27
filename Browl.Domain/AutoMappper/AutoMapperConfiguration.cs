using AutoMapper;

namespace Browl.Domain.AutoMappper;
public class AutoMapperConfiguration
{
	public static IMapperConfigurationExpression RegisterMappings(IMapperConfigurationExpression configuration)
	{
		configuration.AddProfile(new CommandToDomainMappingProfile());
		configuration.AddProfile(new DomainToViewModelMappingProfile());
		return configuration;
	}

}
