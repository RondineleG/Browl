using Browl.Service.AuthSecurity.Application.Contracts.Identity;
using Browl.Service.AuthSecurity.Application.Models.Identity;

using Microsoft.AspNetCore.Mvc;

namespace Browl.Service.AuthSecurity.Api.Controllers.v2
{
	[Route("api/v2/identity/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authenticationService;

		public AuthController(IAuthService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		[HttpPost("login")]
		public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
		{
			return Ok(await _authenticationService.Login(request));
		}

		[HttpPost("register")]
		public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
		{
			return Ok(await _authenticationService.Register(request));
		}
	}
}
