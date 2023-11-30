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
	private readonly ITokenService _tokenService;

	public AuthenticationService(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
	{
		_userRepository = userRepository;
		_mapper = mapper;
		_tokenService = tokenService;
	}

	public async Task<AuthenticationVM> Authenticate(AutenticationCommand command) {

		Validate(command, new AuthenticationValidator());

		var user = _mapper.Map<User>(command);
		
		string passwordHash = command.Password; 
		user = await _userRepository.Authenticate(user, passwordHash);
		if (user == null)
		{
			return null;
		}
		var vm = _mapper.Map<AuthenticationVM>(user);
		vm.JWT = await _tokenService.GenerateToken(user);

		return vm;
	}

	public async Task<int> CreateUser(CreateUserCommand command)
	{
		Validate(command, new CreateUserValidator());
		var userExists = await _userRepository.VerifyUserExist(command.Email);
		if (userExists)
		{
			throw new ArgumentException("Usuário ja existe");
		}

	}
}
