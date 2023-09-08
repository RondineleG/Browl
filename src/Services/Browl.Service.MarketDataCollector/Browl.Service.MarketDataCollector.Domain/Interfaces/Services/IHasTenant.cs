namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface IHasTenant
{
	public string TenantName { get; set; }
}