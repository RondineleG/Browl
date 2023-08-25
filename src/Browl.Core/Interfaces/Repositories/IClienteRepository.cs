using Browl.Core.Entities;

namespace Browl.Core.Interfaces.Repositories;

public interface IClienteRepository
{
    Task<Cliente> DeleteClienteAsync(int id);

    Task<Cliente> GetClienteAsync(int id);

    Task<IEnumerable<Cliente>> GetClientesAsync();

    Task<Cliente> InsertClienteAsync(Cliente cliente);

    Task<Cliente> UpdateClienteAsync(Cliente cliente);
}