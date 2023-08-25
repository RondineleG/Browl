using Browl.Core.Entities;

namespace Browl.Core.Interfaces.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAsync();

    Task<Usuario> GetAsync(string login);

    Task<Usuario> InsertAsync(Usuario usuario);

    Task<Usuario> UpdateAsync(Usuario usuario);
}