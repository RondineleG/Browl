using Browl.Service.AuthSecurity.Application.Models.Identity;

namespace Browl.Service.AuthSecurity.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);

    }
}
