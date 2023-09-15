using AutoMapper;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.User;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, UserViewResource>().ReverseMap();
		CreateMap<User, UserNewResource>().ReverseMap();
		CreateMap<User, UserLoggedResource>().ReverseMap();
		CreateMap<Role, RoleViewResource>().ReverseMap();
		CreateMap<Role, ReferenceRoleResource>().ReverseMap();
	}
}
