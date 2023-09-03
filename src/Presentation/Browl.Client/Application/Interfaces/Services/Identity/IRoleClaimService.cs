using Browl.Application.Interfaces.Common;
using Browl.Application.Requests.Identity;
using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}