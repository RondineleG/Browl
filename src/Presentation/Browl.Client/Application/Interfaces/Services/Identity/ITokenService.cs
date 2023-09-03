using Browl.Application.Interfaces.Common;
using Browl.Application.Requests.Identity;
using Browl.Application.Responses.Identity;
using Browl.Shared.Wrapper;
using System.Threading.Tasks;

namespace Browl.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}