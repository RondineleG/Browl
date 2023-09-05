using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public UserRepository(BrowlDbContext context) : base(context) { }

    public async Task<IEnumerable<User>> GetAsync()
    {
        return await _browlDbContext.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetAsync(string login)
    {
        return await _browlDbContext.Users
            .Include(p => p.Roles)
            .AsNoTracking()
            .SingleOrDefaultAsync(p => p.Login == login);
    }

    public async Task<User> InsertAsync(User usuario)
    {
        await InsertUsuarioFuncaoAsync(usuario);
        await _browlDbContext.Users.AddAsync(usuario);
        await _browlDbContext.SaveChangesAsync();
        return usuario;
    }

    private async Task InsertUsuarioFuncaoAsync(User usuario)
    {
        var funcoesConsultas = new List<Role>();
        foreach (var funcao in usuario.Roles)
        {
            var funcaoConsultada = await _browlDbContext.Roles.FindAsync(funcao.Id);
            funcoesConsultas.Add(funcaoConsultada);
        }
        usuario.Roles = funcoesConsultas;
    }

    public async Task<User> UpdateAsync(User usuario)
    {
        var usuarioConsultado = await _browlDbContext.Users.FindAsync(usuario.Login);
        if (usuarioConsultado == null)
        {
            return null;
        }
        _browlDbContext.Entry(usuarioConsultado).CurrentValues.SetValues(usuario);
        await _browlDbContext.SaveChangesAsync();
        return usuarioConsultado;
    }
}