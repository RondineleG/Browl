using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAsync();

    Task<Usuario> GetAsync(string login);

    Task<Usuario> InsertAsync(Usuario usuario);

    Task<Usuario> UpdateAsync(Usuario usuario);
}