namespace Browl.Service.MarketDataCollector.Domain.Resources.Category;

public record CategoryResource
{
	public int Id { get; init; }
	public string Name { get; init; } = null!;
}
