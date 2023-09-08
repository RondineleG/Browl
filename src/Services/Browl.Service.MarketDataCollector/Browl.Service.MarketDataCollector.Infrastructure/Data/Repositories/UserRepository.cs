using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
	public UserRepository(BrowlDbContext bowlDbContext) : base(bowlDbContext)
	{
	}

	public async Task<IEnumerable<User>> GetAsync() => await _browlDbContext.Users.AsNoTracking().ToListAsync();

	public async Task<User> GetAsync(string login) => await _browlDbContext.Users
			.Include(p => p.Roles)
			.AsNoTracking()
			.SingleOrDefaultAsync(p => p.Login == login);

	public async Task<User> InsertAsync(User usuario)
	{
		await InsertUsuarioFuncaoAsync(usuario);
		_ = await _browlDbContext.Users.AddAsync(usuario);
		_ = await _browlDbContext.SaveChangesAsync();
		return usuario;
	}

	private async Task InsertUsuarioFuncaoAsync(User usuario)
	{
		List<Role> searchingRoles = new();
		foreach (var funcao in usuario.Roles)
		{
			var role = await _browlDbContext.Roles.FindAsync(funcao.Id);
			searchingRoles.Add(role);
		}
		usuario.Roles = searchingRoles;
	}

	public async Task<User> UpdateAsync(User user)
	{
		var usuarioConsultado = await _browlDbContext.Users.FindAsync(user.Login);
		if (usuarioConsultado == null)
		{
			return null;
		}
		_browlDbContext.Entry(usuarioConsultado).CurrentValues.SetValues(user);
		_ = await _browlDbContext.SaveChangesAsync();
		return usuarioConsultado;
	}
}