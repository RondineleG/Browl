using System.Security.Claims;

using Browl.Service.AuthSecurity.Application.Contracts.Identity;
using Browl.Service.AuthSecurity.Application.Models.Identity;
using Browl.Service.AuthSecurity.Identity.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.Identity.Services;

public class UserService : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly IHttpContextAccessor _contextAccessor;

	public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
	{
		_userManager = userManager;
		_contextAccessor = contextAccessor;
	}

	public string? UserId => _contextAccessor.HttpContext?.User?.FindFirstValue("uid");

	public async Task<Employee> GetEmployeeAsync(string userId)
	{
		var employee = await _userManager.FindByIdAsync(userId);
		return new Employee
		{
			Email = employee.Email,
			Id = employee.Id,
			Firstname = employee.FirstName,
			Lastname = employee.LastName
		};
	}

	public async Task<List<Employee>> GetEmployeesAsync()
	{
		var employees = await _userManager.GetUsersInRoleAsync("Employee");
		return employees.Select(q => new Employee
		{
			Id = q.Id,
			Email = q.Email,
			Firstname = q.FirstName,
			Lastname = q.LastName
		}).ToList();
	}
}
