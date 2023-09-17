using Browl.Service.AuthSecurity.API.Resources;

namespace Browl.Service.AuthSecurity.API.Services.Interfaces;

public interface IUserService
{
	Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserRegistrationResources userRegistration);

	bool CheckUserUniqueEmail(string email);

	Task<(bool IsLoginSuccess, JWTTokenResponseResource TokeResponse)> LoginAsync(LoginResource loginPayload);
}
