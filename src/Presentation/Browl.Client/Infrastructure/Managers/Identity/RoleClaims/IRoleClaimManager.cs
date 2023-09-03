using Browl.Application.Requests.Identity;
using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Browl.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}