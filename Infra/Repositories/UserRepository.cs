using Browl.Domain.IRepositories;
using Browl.Domain.Models;
using Browl.Infra.Managers;

using Dapper;

namespace Browl.Infra.Repositories;
public partial class UserRepository : BaseRepository, IUserRepository
{
	public UserRepository(BrowlConnectionManager connectionManager) : base(connectionManager)
	{
	}

	public async Task<User> Authenticate(User user, string passwordhash)
	{
		return await _conn.QueryFirstOrDefaultAsync<User>(
			QueryAuthenticateUser,
			new {
				user.Email,
				passwordhash
			}
		);
	}

	public async Task<bool> VerifyUserExist(string email)
	{
		var userExist =  await _conn.QueryFirstOrDefaultAsync<int>(
			QueryVerifyUserExist,
			new
			{
				email
			}
		);
		return userExist>0;
	}
}
