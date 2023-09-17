﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Browl.Service.AuthSecurity.API.Controllers.Base;
using Browl.Service.AuthSecurity.API.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.AuthSecurity.API.Controllers;

/// <summary>
/// AuthController handles authentication operations like user registration and login.
/// </summary>
/// <remarks>
/// This API controller inherits from MainController to get common error handling methods.
/// It depends on ASP.NET Core Identity for user management.
/// 
/// The main methods are:
/// 
/// - Register: Creates a new user account based on a User model.
/// - Login: Authenticates a user based on a UserLogin model.
/// - GenerateJWT: Generates a JWT token for an authenticated user.
/// - GetClaimsUser: Gets identity claims for a user. 
/// - EncodeToken: Encodes a JWT token from identity claims.
///
/// Both Register and Login return a custom API response via the CustomResponse method.
/// The JWT token is added to the response on success.
/// </remarks>
[Route("api/identity/auth")]
public class AuthController : MainController
{
	private readonly SignInManager<IdentityUser> _signInManager;
	private readonly UserManager<IdentityUser> _userManager;
	private readonly AppSettings _appSettings;

	public AuthController(SignInManager<IdentityUser> signInManager,
						  UserManager<IdentityUser> userManager,
						  IOptions<AppSettings> appSettings)
	{
		_signInManager = signInManager;
		_userManager = userManager;
		_appSettings = appSettings.Value;
	}

	/// <summary>
	/// Registers a new user.
	/// </summary>
	/// <param name="userRegister">The user object containing registration details.</param>
	/// <returns>The result of the registration.</returns>

	[HttpPost("new-account")]
	public async Task<ActionResult> Register(UserRegister userRegister)
	{
		if (!ModelState.IsValid)
		{
			return CustomResponse(ModelState);
		}

		var identityUser = new User
		{
			UserName = userRegister.UserName,
			FirstName = userRegister.FirstName,
			LastName = userRegister.LastName,
			UserNameChangeLimit = userRegister.UserNameChangeLimit,
			ProfilePicture = userRegister.ProfilePicture,
			Email = userRegister.Email,
			EmailConfirmed = true,
			Password = userRegister.Password,
			PasswordConfirmation = userRegister.PasswordConfirmation
		};

		var result = await _userManager.CreateAsync(identityUser, userRegister.Password);

		if (result.Succeeded)
		{
			return CustomResponse(await GenerateJWT(userRegister.Email));
		}

		foreach (var error in result.Errors)
		{
			AddErrorProcessing(error.Description);
		}

		return CustomResponse();
	}

	/// <summary>
	/// Authenticates a user.
	/// </summary>
	/// <param name="usuarioLogin">The user login object containing login details.</param>
	/// <returns>The result of the authentication.</returns>

	/// <summary>
	/// Authenticates a user.
	/// </summary>
	/// <param name="usuarioLogin">The user login object containing login details.</param>
	/// <returns>The result of the authentication.</returns>

	[HttpPost("authenticate")]
	public async Task<ActionResult> Login(UserLogin usuarioLogin)
	{
		if (!ModelState.IsValid)
		{
			return CustomResponse(ModelState);
		}

		var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Password,
			false, true);

		if (result.Succeeded)
		{
			return CustomResponse(await GenerateJWT(usuarioLogin.Email));
		}

		if (result.IsLockedOut)
		{
			AddErrorProcessing("User temporarily blocked for invalid attempts");
			return CustomResponse();
		}

		AddErrorProcessing("Incorrect username or password");
		return CustomResponse();
	}

	/// <summary>
	/// Generates a JWT token for a user.
	/// </summary>
	/// <param name="email">The email of the user.</param>
	/// <returns>The generated JWT token.</returns>

	private async Task<UserResponse> GenerateJWT(string email)
	{
		var user = await _userManager.FindByEmailAsync(email).ConfigureAwait(false);
		var claims = await _userManager.GetClaimsAsync(user).ConfigureAwait(false);
		var identityClaims = await GetClaimsUser(claims, user).ConfigureAwait(false);
		var encodedToken = EncodeToken(identityClaims);
		return GetResponseToken(encodedToken, user, claims);
	}

	/// <summary>
	/// Retrieves claims for a user.
	/// </summary>
	/// <param name="claims">The existing claims for the user.</param>
	/// <param name="user">The user object.</param>
	/// <returns>The claims identity for the user.</returns>
	private async Task<ClaimsIdentity> GetClaimsUser(ICollection<Claim> claims, IdentityUser user)
	{
		var userRoles = await _userManager.GetRolesAsync(user);
		claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
		claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
		claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
		claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
		claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
		foreach (var userRole in userRoles)
		{
			claims.Add(new Claim("role", userRole));
		}
		ClaimsIdentity identityClaims = new();
		identityClaims.AddClaims(claims);

		return identityClaims;
	}

	/// <summary>
	/// Encodes a JWT token from a ClaimsIdentity object.
	/// </summary>
	/// <param name="identityClaims">The ClaimsIdentity containing the claims for the token.</param>
	/// <returns>The encoded JWT token string.</returns>
	/// <remarks>
	/// This method:
	/// - Creates a JwtSecurityTokenHandler instance 
	/// - Gets the secret key from the app settings
	/// - Creates a SecurityTokenDescriptor with:
	///   - Issuer, Audience, Subject, Expiration from app settings
	///   - SigningCredentials using HMAC SHA256 algorithm
	/// - Writes the token using the token handler
	/// - Returns the encoded token string
	/// </remarks>

	private string EncodeToken(ClaimsIdentity identityClaims)
	{
		JwtSecurityTokenHandler tokenHandler = new();
		var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
		var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
		{
			Issuer = _appSettings.Issuer,
			Audience = _appSettings.ValidOn,
			Subject = identityClaims,
			Expires = DateTime.UtcNow.AddHours(_appSettings.ExpirationHours),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		});

		return tokenHandler.WriteToken(token);
	}


	/// <summary>
	/// Returns a UserResponse object containing the encoded JWT token and user details.
	/// </summary>
	/// <param name="encodedToken">The encoded JWT token string.</param>
	/// <param name="user">The IdentityUser object for the authenticated user.</param>
	/// <param name="claims">The list of claims for the user.</param>
	/// <returns>A UserResponse object containing the encoded token and user details.</returns>
	/// <remarks>
	/// This method creates and populates a UserResponse object with:
	/// - The encoded JWT token string
	/// - The token expiration time based on app settings
	/// - A UserToken object containing:
	///   - The user ID
	///   - Email 
	///   - The user claims
	///   
	/// The UserResponse is returned to the client with the authentication response.
	/// </remarks>
	private UserResponse GetResponseToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
	{
		var expiresIn = TimeSpan.FromHours(_appSettings.ExpirationHours).TotalSeconds;
		var userClaims = claims.Select(c => new UserClaim { Type = c.Type, Value = c.Value }).ToList();

		var response = new UserResponse
		{
			AccessToken = encodedToken,
			ExpiresIn = expiresIn,
			UserToken = new UserToken
			{
				Id = user.Id,
				Email = user.Email,
				UserClaims = userClaims
			}
		};

		return response;
	}

	/// <summary>
	/// Converts a DateTime to a Unix epoch timestamp in seconds.
	/// </summary>
	/// <param name="date">The DateTime to convert.</param>
	/// <returns>The Unix timestamp in seconds.</returns>
	/// <remarks>
	/// The Unix epoch (or Unix time or POSIX time or Unix timestamp) is the number of seconds that have elapsed since January 1, 1970. 
	///
	/// This method converts the provided DateTime to a long representing seconds since the Unix epoch by:
	///
	/// - Calling ToUniversalTime() to convert to UTC.
	/// - Subtracting the Unix epoch DateTimeOffset (January 1, 1970).
	/// - Calculating total seconds by calling TotalSeconds on the timespan.
	/// - Casting the double to a long.
	/// - Rounding the seconds value.
	///
	/// The returned long can be used as a Unix timestamp.
	/// </remarks>
	private static long ToUnixEpochDate(DateTime date) => DateTimeOffset.UtcNow.ToUnixTimeSeconds();
}
