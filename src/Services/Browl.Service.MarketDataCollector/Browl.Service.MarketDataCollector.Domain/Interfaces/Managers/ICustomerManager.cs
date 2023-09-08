using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Managers;

public interface ICustomerManager
{
	Task<CustomerResource> DeleteAsync(int id);

	Task<CustomerViewResource> GetAsync(int id);

	Task<IEnumerable<CustomerViewResource>> GetAsync();

	Task<CustomerViewResource> PostAsync(CustomerResource cliente);

	Task<CustomerViewResource> PutAsync(CustomerUpdateResource cliente);
}