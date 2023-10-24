using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.User;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		_ = CreateMap<User, UserViewResource>().ReverseMap();
		_ = CreateMap<User, UserNewResource>().ReverseMap();
		_ = CreateMap<User, UserLoggedResource>().ReverseMap();
		_ = CreateMap<Role, RoleViewResource>().ReverseMap();
		_ = CreateMap<Role, ReferenceRoleResource>().ReverseMap();
	}
}
