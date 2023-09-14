using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;

public interface IUserRepository
{
<<<<<<< HEAD
	Task<IEnumerable<User>> GetAsync();

	Task<User> GetAsync(string login);

	Task<User> InsertAsync(User usuario);

	Task<User> UpdateAsync(User usuario);
=======
    Task<IEnumerable<User>> GetAsync();

    Task<User> GetAsync(string login);

    Task<User> InsertAsync(User usuario);

    Task<User> UpdateAsync(User usuario);
>>>>>>> dev
}