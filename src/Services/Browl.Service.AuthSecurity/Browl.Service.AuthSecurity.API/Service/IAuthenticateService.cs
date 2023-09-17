using System.Security.Claims;

using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;

namespace Browl.Service.AuthSecurity.API.Service;

public interface IAuthenticateService
{
	Task<UserResponse> GenerateJWT(string email);
}
