using Browl.Domain.Models;

namespace Browl.Domain.IRepositories;
public interface IUserRepository
{
	Task<User> Authenticate(User user, string passwordhash);
}
