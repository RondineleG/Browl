using AutoMapper;
<<<<<<< HEAD

=======
>>>>>>> dev
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.User;
<<<<<<< HEAD

=======
>>>>>>> dev
using Microsoft.AspNetCore.Identity;

namespace Browl.Service.MarketDataCollector.Application.Implementation;

public class UserManager : IUserManager
{
<<<<<<< HEAD
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;
	private readonly IJwtService _jwtService;

	public UserManager(IUserRepository repository, IMapper mapper, IJwtService jwtService)
	{
		_userRepository = repository;
		_mapper = mapper;
		_jwtService = jwtService;
	}

	public async Task<IEnumerable<UserViewResource>> GetAsync() => _mapper.Map<IEnumerable<User>, IEnumerable<UserViewResource>>(await _userRepository.GetAsync());

	public async Task<UserViewResource> GetAsync(string login) => _mapper.Map<UserViewResource>(await _userRepository.GetAsync(login));

	public async Task<UserViewResource> InsertAsync(UserNewResource novoUsuario)
	{
		var usuario = _mapper.Map<User>(novoUsuario);
		ConverteSenhaEmHash(usuario);
		return _mapper.Map<UserViewResource>(await _userRepository.InsertAsync(usuario));
	}

	private static void ConverteSenhaEmHash(User usuario)
	{
		PasswordHasher<User> passwordHasher = new();
		usuario.Password = passwordHasher.HashPassword(usuario, usuario.Password);
	}

	public async Task<UserViewResource> UpdateMedicoAsync(User usuario)
	{
		ConverteSenhaEmHash(usuario);
		return _mapper.Map<UserViewResource>(await _userRepository.UpdateAsync(usuario));
	}

	public async Task<UserLoggedResource?> ValidaUsuarioEGeraTokenAsync(User usuario)
	{
		var usuarioConsultado = await _userRepository.GetAsync(usuario.Login);
		if (usuarioConsultado == null)
		{
			return null;
		}
		if (await ValidateAndUpdateHashAsync(usuario, usuarioConsultado.Password))
		{
			var usuarioLogado = _mapper.Map<UserLoggedResource>(usuarioConsultado);
			usuarioLogado.Token = _jwtService.GenerateToken(usuarioConsultado);
			return usuarioLogado;
		}
		return null;
	}

	private async Task<bool> ValidateAndUpdateHashAsync(User usuario, string hash)
	{
		PasswordHasher<User> passwordHasher = new();
		var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Password);
		switch (status)
		{
			case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed:
				return false;

			case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success:
				return true;

			case Microsoft.AspNetCore.Identity.PasswordVerificationResult.SuccessRehashNeeded:
				_ = await UpdateMedicoAsync(usuario);
				return true;

			default:
				throw new InvalidOperationException();
		}
	}
=======
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;

    public UserManager(IUserRepository repository, IMapper mapper, IJwtService jwtService)
    {
        _userRepository = repository;
        _mapper = mapper;
        _jwtService = jwtService;
    }

    public async Task<IEnumerable<UserViewResource>> GetAsync()
    {
        return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewResource>>(await _userRepository.GetAsync());
    }

    public async Task<UserViewResource> GetAsync(string login)
    {
        return _mapper.Map<UserViewResource>(await _userRepository.GetAsync(login));
    }

    public async Task<UserViewResource> InsertAsync(UserNewResource novoUsuario)
    {
        var usuario = _mapper.Map<User>(novoUsuario);
        ConverteSenhaEmHash(usuario);
        return _mapper.Map<UserViewResource>(await _userRepository.InsertAsync(usuario));
    }

    private static void ConverteSenhaEmHash(User usuario)
    {
        var passwordHasher = new PasswordHasher<User>();
        usuario.Password = passwordHasher.HashPassword(usuario, usuario.Password);
    }

    public async Task<UserViewResource> UpdateMedicoAsync(User usuario)
    {
        ConverteSenhaEmHash(usuario);
        return _mapper.Map<UserViewResource>(await _userRepository.UpdateAsync(usuario));
    }

    public async Task<UserLoggedResource> ValidaUsuarioEGeraTokenAsync(User usuario)
    {
        var usuarioConsultado = await _userRepository.GetAsync(usuario.Login);
        if (usuarioConsultado == null)
        {
            return null;
        }
        if (await ValidateAndUpdateHashAsync(usuario, usuarioConsultado.Password))
        {
            var usuarioLogado = _mapper.Map<UserLoggedResource>(usuarioConsultado);
            usuarioLogado.Token = _jwtService.GenerateToken(usuarioConsultado);
            return usuarioLogado;
        }
        return null;
    }

    private async Task<bool> ValidateAndUpdateHashAsync(User usuario, string hash)
    {
        var passwordHasher = new PasswordHasher<User>();
        var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Password);
        switch (status)
        {
            case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Failed:
                return false;

            case Microsoft.AspNetCore.Identity.PasswordVerificationResult.Success:
                return true;

            case Microsoft.AspNetCore.Identity.PasswordVerificationResult.SuccessRehashNeeded:
                await UpdateMedicoAsync(usuario);
                return true;

            default:
                throw new InvalidOperationException();
        }
    }
>>>>>>> dev
}