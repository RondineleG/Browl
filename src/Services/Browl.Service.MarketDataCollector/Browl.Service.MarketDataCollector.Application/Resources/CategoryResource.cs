namespace Browl.Service.MarketDataCollector.Application.Resources;

public record CategoryResource
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
}