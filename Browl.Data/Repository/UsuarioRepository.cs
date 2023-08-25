using Browl.Core.Entities;
using Browl.Core.Interfaces.Repositories;
using Browl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data.Repository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public UsuarioRepository(BrowlDbContext browlDbContext)
    {
        _browlDbContext = browlDbContext;
    }

    public async Task<IEnumerable<Usuario>> GetAsync()
    {
        return await _browlDbContext.Usuarios.AsNoTracking().ToListAsync();
    }

    public async Task<Usuario> GetAsync(string login)
    {
        return await _browlDbContext.Usuarios
            .Include(p => p.Funcoes)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Login == login);
    }

    public async Task<Usuario> InsertAsync(Usuario usuario)
    {
        await InsertUsuarioFuncaoAsync(usuario);
        await _browlDbContext.Usuarios.AddAsync(usuario);
        await _browlDbContext.SaveChangesAsync();
        return usuario;
    }

    private async Task InsertUsuarioFuncaoAsync(Usuario usuario)
    {
        var funcoesConsultas = new List<Funcao>();
        foreach (var funcao in usuario.Funcoes)
        {
            var funcaoConsultada = await _browlDbContext.Funcoes.FindAsync(funcao.Id);
            funcoesConsultas.Add(funcaoConsultada);
        }
        usuario.Funcoes = funcoesConsultas;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        var usuarioConsultado = await _browlDbContext.Usuarios.FindAsync(usuario.Login);
        if (usuarioConsultado == null)
        {
            return null;
        }
        _browlDbContext.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
        await _browlDbContext.SaveChangesAsync();
        return usuarioConsultado;
    }
}