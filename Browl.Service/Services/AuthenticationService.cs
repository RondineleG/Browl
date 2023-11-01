using AutoMapper;

using Browl.Domain.Commands.Login;
using Browl.Domain.IRepositories;
using Browl.Domain.IServices;
using Browl.Domain.Models;
using Browl.Domain.ViewModels.Login;
using Browl.Service.Validators.Login;

namespace Browl.Service.Services;
public class AuthenticationService : BaseService, IAuthenticationService
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public AuthenticationService(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
	}

	public async Task<AuthenticationVM> Authenticate(AutenticationCommand command) {
		Validate(command, new AuthenticationValidator());

		var user = _mapper.Map<User>(command);
		
		string passwordHash = command.Password; //Aqui precisa fazer o esquema pra gerar o hash da senha pra validar na base;
		user = await _userRepository.Authenticate(user, passwordHash);

		var vm = _mapper.Map<AuthenticationVM>(user);
		vm.JWT = "Precisa implementar a geração do JWT";

		return vm;
	}
}
