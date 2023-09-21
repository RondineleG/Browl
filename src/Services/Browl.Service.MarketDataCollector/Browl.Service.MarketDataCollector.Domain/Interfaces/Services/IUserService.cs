using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.User;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

public interface IUserService
{
	Task<IEnumerable<UserViewResource>> GetAsync();

	Task<UserViewResource> GetAsync(string login);

	Task<UserViewResource> InsertAsync(UserNewResource usuario);

	Task<UserViewResource> UpdateMedicoAsync(User usuario);

	Task<UserLoggedResource> ValidaUsuarioEGeraTokenAsync(User usuario);
}
