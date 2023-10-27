using AutoMapper;

using Browl.Domain.Commands.Login;
using Browl.Domain.Models;

namespace Browl.Domain.AutoMappper;
internal class CommandToDomainMappingProfile : Profile
{
	public CommandToDomainMappingProfile()
	{
		CreateMap<AutenticationCommand, User>();
	}
}
