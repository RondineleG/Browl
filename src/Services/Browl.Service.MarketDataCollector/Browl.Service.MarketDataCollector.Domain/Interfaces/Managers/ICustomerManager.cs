using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;

public interface ICustomerManager
{
    Task<CustomerResource> DeleteClienteAsync(int id);

    Task<CustomerViewResource> GetClienteAsync(int id);

    Task<IEnumerable<CustomerViewResource>> GetClientesAsync();

    Task<CustomerViewResource> InsertClienteAsync(CustomerResource cliente);

    Task<CustomerViewResource> UpdateClienteAsync(CustomerUpdateResource cliente);
}