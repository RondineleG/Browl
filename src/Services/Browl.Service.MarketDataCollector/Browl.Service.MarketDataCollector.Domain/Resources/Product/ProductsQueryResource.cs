using Browl.Service.MarketDataCollector.Domain.Resources.Query;

namespace Browl.Service.MarketDataCollector.Domain.Resources.Product;

public record ProductsQueryResource : QueryResource
{
	public int CategoryId { get; init; }
}