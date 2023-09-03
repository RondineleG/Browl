using AutoMapper;
using Browl.Service.MarketDataCollector.Domain.Dtos.Usuario;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace Browl.Service.MarketDataCollector.Application.Implementation;

public class UsuarioManager : IUsuarioManager
{
    private readonly IUsuarioRepository repository;
    private readonly IMapper mapper;
    private readonly IJwtService jwt;

    public UsuarioManager()
    {
            
    }
    public UsuarioManager(IUsuarioRepository repository, IMapper mapper, IJwtService jwt)
    {
        this.repository = repository;
        this.mapper = mapper;
        this.jwt = jwt;
    }

    public async Task<IEnumerable<UsuarioView>> GetAsync()
    {
        return mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioView>>(await repository.GetAsync());
    }

    public async Task<UsuarioView> GetAsync(string login)
    {
        return mapper.Map<UsuarioView>(await repository.GetAsync(login));
    }

    public async Task<UsuarioView> InsertAsync(NovoUsuario novoUsuario)
    {
        var usuario = mapper.Map<Usuario>(novoUsuario);
        ConverteSenhaEmHash(usuario);
        return mapper.Map<UsuarioView>(await repository.InsertAsync(usuario));
    }

    private static void ConverteSenhaEmHash(Usuario usuario)
    {
        var passwordHasher = new PasswordHasher<Usuario>();
        usuario.Senha = passwordHasher.HashPassword(usuario, usuario.Senha);
    }

    public async Task<UsuarioView> UpdateMedicoAsync(Usuario usuario)
    {
        ConverteSenhaEmHash(usuario);
        return mapper.Map<UsuarioView>(await repository.UpdateAsync(usuario));
    }

    public async Task<UsuarioLogado> ValidaUsuarioEGeraTokenAsync(Usuario usuario)
    {
        var usuarioConsultado = await repository.GetAsync(usuario.Login);
        if (usuarioConsultado == null)
        {
            return null;
        }
        if (await ValidaEAtualizaHashAsync(usuario, usuarioConsultado.Senha))
        {
            var usuarioLogado = mapper.Map<UsuarioLogado>(usuarioConsultado);
            usuarioLogado.Token = jwt.GenerateToken(usuarioConsultado);
            return usuarioLogado;
        }
        return null;
    }

    private async Task<bool> ValidaEAtualizaHashAsync(Usuario usuario, string hash)
    {
        var passwordHasher = new PasswordHasher<Usuario>();
        var status = passwordHasher.VerifyHashedPassword(usuario, hash, usuario.Senha);
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