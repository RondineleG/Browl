using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class UsuarioRepository : BaseRepository, IUsuarioRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public UsuarioRepository(BrowlDbContext context) : base(context) { }

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