namespace Browl.Service.MarketDataCollector.Domain.Queries.Base;

public class QueryResult<T>
{
	public List<T> Items { get; set; } = new List<T>();
	public int TotalItems { get; set; } = 0;
}