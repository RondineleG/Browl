using Browl.Service.AuthSecurity.Application.Models.Identity;

namespace Browl.Service.AuthSecurity.Application.Contracts.Identity;

/// <summary>
/// I user service
/// </summary>
public interface IUserService
{
	Task<List<Employee>> GetEmployeesAsync();
	Task<Employee> GetEmployeeAsync(string userId);
	/// <summary>
	/// User id
	/// </summary>
	/// <value cref="string">string</value>
	public string UserId { get; }
}
