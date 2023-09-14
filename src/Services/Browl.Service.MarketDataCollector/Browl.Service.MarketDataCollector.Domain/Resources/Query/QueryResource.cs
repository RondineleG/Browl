<<<<<<< HEAD
namespace Browl.Service.MarketDataCollector.Domain.Resources.Query;

public record QueryResource
{
	public int Page { get; init; }
	public int ItemsPerPage { get; init; }
=======
namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record QueryResource
    {
        public int Page { get; init; }
        public int ItemsPerPage { get; init; }
    }
>>>>>>> dev
}