using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Browl.Service.MarketDataCollector.Domain.Resources.User;
using Microsoft.AspNetCore.Identity;

namespace Browl.Service.MarketDataCollector.Application.Implementation;

public class UserManager : IUserManager
{
    private readonly IUserRepository repository;
    private readonly IMapper mapper;
    private readonly IJwtService jwt;

    public UserManager()
    {

    }
    public UserManager(IUserRepository repository, IMapper mapper, IJwtService jwt)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.jwt = jwt;
    }

    public async Task<IEnumerable<UserViewResource>> GetAsync()
    {
        return mapper.Map<IEnumerable<User>, IEnumerable<UserViewResource>>(await repository.GetAsync());
    }

    public async Task<UserViewResource> GetAsync(string login)
    {
        return mapper.Map<UserViewResource>(await repository.GetAsync(login));
    }

    public async Task<UserViewResource> InsertAsync(UserNewResource novoUsuario)
    {
        var usuario = mapper.Map<User>(novoUsuario);
        ConverteSenhaEmHash(usuario);
        return mapper.Map<UserViewResource>(await repository.InsertAsync(usuario));
    }

    private static void ConverteSenhaEmHash(User usuario)
    {
        var passwordHasher = new PasswordHasher<User>();
        usuario.Password = passwordHasher.HashPassword(usuario, usuario.Password);
    }

    public async Task<UserViewResource> UpdateMedicoAsync(User usuario)
    {
        ConverteSenhaEmHash(usuario);
        return mapper.Map<UserViewResource>(await repository.UpdateAsync(usuario));
    }

    public async Task<UserLoggedResource> ValidaUsuarioEGeraTokenAsync(User usuario)
    {
        var usuarioConsultado = await repository.GetAsync(usuario.Login);
        if (usuarioConsultado == null)
        {
            return null;
        }
        if (await ValidaEAtualizaHashAsync(usuario, usuarioConsultado.Password))
        {
            var usuarioLogado = mapper.Map<UserLoggedResource>(usuarioConsultado);
            usuarioLogado.Token = jwt.GenerateToken(usuarioConsultado);
            return usuarioLogado;
        }
        return null;
    }

    private async Task<bool> ValidaEAtualizaHashAsync(User usuario, string hash)
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
}