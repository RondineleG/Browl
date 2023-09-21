using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly BrowlServiceMarketDataCollectorDbContext _context;

	public UnitOfWork(BrowlServiceMarketDataCollectorDbContext context) => _context = context;
	public async Task CompleteAsync() => _ = await _context.SaveChangesAsync();
}