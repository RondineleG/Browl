using Browl.Service.MarketDataCollector.Domain.Communication;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Queries;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<QueryResult<Product>> ListAsync(ProductsQuery query);
        Task<Response<Product>> SaveAsync(Product product);
        Task<Response<Product>> UpdateAsync(int id, Product product);
        Task<Response<Product>> DeleteAsync(int id);
    }
}