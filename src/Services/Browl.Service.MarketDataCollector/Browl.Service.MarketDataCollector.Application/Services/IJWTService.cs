using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Application.Services;

public interface IJwtService
{
    string GerarToken(User usuario);
}