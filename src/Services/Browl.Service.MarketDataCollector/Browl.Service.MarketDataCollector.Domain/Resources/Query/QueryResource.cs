namespace Browl.Service.MarketDataCollector.Domain.Resources.Query;

public record QueryResource
{
	public int Page { get; init; }
	public int ItemsPerPage { get; init; }
}
