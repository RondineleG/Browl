using Browl.Service.AuthSecurity.Application.Models.Identity;

namespace Browl.Service.AuthSecurity.Application.Contracts.Identity;

/// <summary>
/// I auth service
/// </summary>
public interface IAuthService
{
	Task<AuthResponse> LoginAsync(AuthRequest request);
	Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);

}
