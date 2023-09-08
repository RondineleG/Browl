using Browl.Service.MarketDataCollector.Domain.Communication;
using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface ICategoryService
{
	Task<IEnumerable<Category>> ListAsync();
	Task<Response<Category>> SaveAsync(Category category);
	Task<Response<Category>> UpdateAsync(int id, Category category);
	Task<Response<Category>> DeleteAsync(int id);
}