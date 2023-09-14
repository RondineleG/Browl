<<<<<<< HEAD
namespace Browl.Service.MarketDataCollector.Domain.Resources.Query;

public record QueryResultResource<T>
{
	public int TotalItems { get; init; } = 0;
	public List<T> Items { get; init; } = new();
=======
namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record QueryResultResource<T>
    {
        public int TotalItems { get; init; } = 0;
        public List<T> Items { get; init; } = new();
    }
>>>>>>> dev
}