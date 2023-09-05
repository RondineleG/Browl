namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record QueryResultResource<T>
    {
        public int TotalItems { get; init; } = 0;
        public List<T> Items { get; init; } = new();
    }
}