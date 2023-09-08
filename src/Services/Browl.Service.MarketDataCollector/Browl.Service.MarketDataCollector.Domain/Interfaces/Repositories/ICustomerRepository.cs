using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
	Task<Customer> DeleteAsync(int id);

	Task<Customer> GetAsync(int id);

	Task<IEnumerable<Customer>> GetAsync();

	Task<Customer> PostAsync(Customer cliente);

	Task<Customer> PutAsync(Customer cliente);
}