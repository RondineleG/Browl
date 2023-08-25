using Browl.Core.Dtos.Cliente;

namespace Browl.Core.Interfaces.Managers;

public interface IClienteManager
{
    Task<ClienteView> DeleteClienteAsync(int id);

    Task<ClienteView> GetClienteAsync(int id);

    Task<IEnumerable<ClienteView>> GetClientesAsync();

    Task<ClienteView> InsertClienteAsync(NovoCliente cliente);

    Task<ClienteView> UpdateClienteAsync(AlteraCliente cliente);
}