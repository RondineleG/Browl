using AutoMapper;

using Browl.Domain.Models;
using Browl.Domain.ViewModels.Login;

namespace Browl.Domain.AutoMappper;
internal class DomainToViewModelMappingProfile : Profile
{
	public DomainToViewModelMappingProfile()
	{
		CreateMap<User, AuthenticationVM>();
	}
}
