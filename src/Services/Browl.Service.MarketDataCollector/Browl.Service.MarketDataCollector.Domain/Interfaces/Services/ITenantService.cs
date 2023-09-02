using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;
public interface ITenantService
{
    public string GetConnectionString();
    public Tenant GetTenant();
}