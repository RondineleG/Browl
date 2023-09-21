using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public abstract class BaseRepository
{
	protected readonly BrowlServiceMarketDataCollectorDbContext _browlDbContext;

	public BaseRepository(BrowlServiceMarketDataCollectorDbContext bowlDbContext) => _browlDbContext = bowlDbContext;
}