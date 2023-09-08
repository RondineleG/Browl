using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories
{
	public abstract class BaseRepository
	{
		protected readonly BrowlDbContext _browlDbContext;

		public BaseRepository(BrowlDbContext bowlDbContext)
		{
			_browlDbContext = bowlDbContext;
		}
	}
}