using Browl.Service.AuthSecurity.API.Controllers;
using Browl.Service.AuthSecurity.API.Entities;
using Browl.Service.AuthSecurity.API.Services;
using Browl.Service.AuthSecurity.API.Services.Interfaces;
using Browl.Service.AuthSecurity.API.Test.Builder;

using FluentAssertions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using NSubstitute;

namespace Browl.Service.AuthSecurity.API.Test
{
	public class AuthControllerTest 
	{
		private readonly AuthController _authController;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IOptions<AppSettings> _appSettings;
		private readonly IAuthenticateService _authenticateService;
		public AuthControllerTest()
		{
			_signInManager = Substitute.For<SignInManager<IdentityUser>>(
				Substitute.For<UserManager<IdentityUser>>(
					Substitute.For<IUserStore<IdentityUser>>(), null, null, null, null, null),
				Substitute.For<IHttpContextAccessor>(),
				Substitute.For<IUserClaimsPrincipalFactory<IdentityUser>>(),
				null, null, null, null);

			_userManager = Substitute.For<UserManager<IdentityUser>>(
				Substitute.For<IUserStore<IdentityUser>>(),
				null, null, null, null, null, null, null, null);

			_appSettings.Value.Returns(new AppSettings());


			_authController = new AuthController(_signInManager, _userManager, _appSettings, _authenticateService);

		}

		[Fact]
		public async Task Register_IsValidModel_ReturnsOkResult()
		{
			// Arrange
			var randomUser = RandomUserGenerator.GenerateRandomUser();

			// Configurar o mock para retornar IdentityResult.Success
			_userManager.CreateAsync(Arg.Any<IdentityUser>(), Arg.Any<string>())
				.Returns(Task.FromResult(IdentityResult.Success));

			// Act
			var result = await _authController.Register(randomUser);

			// Assert
			var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
			var userResponse = okResult.Value.Should().BeAssignableTo<UserResponse>().Subject;

		}

	}
}
