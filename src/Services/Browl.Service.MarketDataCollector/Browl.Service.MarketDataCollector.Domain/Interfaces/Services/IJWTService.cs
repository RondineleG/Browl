using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(User user);
}