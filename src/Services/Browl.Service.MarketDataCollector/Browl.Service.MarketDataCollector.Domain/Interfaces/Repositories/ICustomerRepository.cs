using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Customer> DeleteClienteAsync(int id);

    Task<Customer> GetClienteAsync(int id);

    Task<IEnumerable<Customer>> GetClientesAsync();

    Task<Customer> InsertClienteAsync(Customer cliente);

    Task<Customer> UpdateClienteAsync(Customer cliente);
}