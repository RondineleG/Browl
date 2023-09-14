<<<<<<< HEAD
using Browl.Service.MarketDataCollector.Domain.Resources.Category;

namespace Browl.Service.MarketDataCollector.Domain.Resources.Product;

public record ProductResource
{
	public int Id { get; init; }
	public string Name { get; init; } = null!;
	public int QuantityInPackage { get; init; }
	public string UnitOfMeasurement { get; init; } = null!;
	public required CategoryResource Category { get; init; }
=======
namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record ProductResource
    {
        public int Id { get; init; }
        public string Name { get; init; } = null!;
        public int QuantityInPackage { get; init; }
        public string UnitOfMeasurement { get; init; } = null!;
        public CategoryResource Category { get; init; }
    }
>>>>>>> dev
}