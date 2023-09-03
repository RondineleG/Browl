namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record ProductsQueryResource : QueryResource
    {
        public int CategoryId { get; init; }
    }
}