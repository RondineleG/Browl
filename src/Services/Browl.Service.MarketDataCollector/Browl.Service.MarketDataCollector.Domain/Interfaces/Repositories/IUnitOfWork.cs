namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
	Task CompleteAsync();
}