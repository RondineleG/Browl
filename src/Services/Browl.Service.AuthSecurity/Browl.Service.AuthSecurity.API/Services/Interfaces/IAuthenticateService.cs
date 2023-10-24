using Browl.Service.AuthSecurity.API.Entities;

namespace Browl.Service.AuthSecurity.API.Services.Interfaces;

public interface IAuthenticateService
{
	Task<UserResponse> GenerateJWT(string email);
}
