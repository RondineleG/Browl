using Browl.Service.AuthSecurity.Application.Models.Identity;

namespace Browl.Service.AuthSecurity.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
        public string UserId { get; }
    }
}
