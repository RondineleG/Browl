using Browl.Service.MarketDataCollector.Domain.Dtos.Cliente;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;

public interface IClienteManager
{
    Task<ClienteView> DeleteClienteAsync(int id);

    Task<ClienteView> GetClienteAsync(int id);

    Task<IEnumerable<ClienteView>> GetClientesAsync();

    Task<ClienteView> InsertClienteAsync(NovoCliente cliente);

    Task<ClienteView> UpdateClienteAsync(AlteraCliente cliente);
}