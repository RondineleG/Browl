using Browl.Application.Interfaces.Common;
using Browl.Application.Requests.Identity;
using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Application.Interfaces.Services.Identity
{
    public interface IRoleService : IService
    {
        Task<Result<List<RoleResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleResponse>> GetByIdAsync(string id);

        Task<Result<string>> SaveAsync(RoleRequest request);

        Task<Result<string>> DeleteAsync(string id);

        Task<Result<PermissionResponse>> GetAllPermissionsAsync(string roleId);

        Task<Result<string>> UpdatePermissionsAsync(PermissionRequest request);
    }
}