using AutoMapper;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Browl.Domain.IServices;
using Browl.Service.Services;
using Browl.Domain.Models;
using Browl.CrossCutting;

namespace Bowl.Service.Services
{
	public class TokenService : BaseService, ITokenService
	{
		public Task <string> GenerateToken(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(Settings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Nome.ToString()),
					new Claim(ClaimTypes.Sid, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddHours(2),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return Task.FromResult(tokenHandler.WriteToken(token));
			Console.WriteLine("teste");
		}
	}
}
