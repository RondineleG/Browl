using AutoMapper;
<<<<<<< HEAD

=======
>>>>>>> dev
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.User;

namespace Browl.Service.MarketDataCollector.Application.Mappings;

public class UserProfile : Profile
{
<<<<<<< HEAD
	public UserProfile()
	{
		_ = CreateMap<User, UserViewResource>().ReverseMap();
		_ = CreateMap<User, UserNewResource>().ReverseMap();
		_ = CreateMap<User, UserLoggedResource>().ReverseMap();
		_ = CreateMap<Role, RoleViewResource>().ReverseMap();
		_ = CreateMap<Role, ReferenceRoleResource>().ReverseMap();
	}
=======
    public UserProfile()
    {
        CreateMap<User, UserViewResource>().ReverseMap();
        CreateMap<User, UserNewResource>().ReverseMap();
        CreateMap<User, UserLoggedResource>().ReverseMap();
        CreateMap<Role, RoleViewResource>().ReverseMap();
        CreateMap<Role, ReferenceRoleResource>().ReverseMap();
    }
>>>>>>> dev
}