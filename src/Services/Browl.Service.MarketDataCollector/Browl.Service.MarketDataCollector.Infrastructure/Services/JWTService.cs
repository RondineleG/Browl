using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Services;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Browl.Service.MarketDataCollector.Infrastructure.Services;

public class JwtService : IJwtService
{
	private readonly IConfiguration _configuration;

	public JwtService(IConfiguration configuration) => _configuration = configuration;

	public string GenerateToken(User usuario)
	{
		JwtSecurityTokenHandler tokenHandler = new();
		var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWT:Secret").Value);
		List<Claim> claims = new()
		{
				new Claim(ClaimTypes.Name, usuario.Login)
			};
		claims.AddRange(usuario.Roles.Select(p => new Claim(ClaimTypes.Role, p.Descricao)));
		SecurityTokenDescriptor tokenDescriptor = new()
		{
			Subject = new ClaimsIdentity(claims),
			Audience = _configuration.GetSection("JWT:Audience").Value,
			Issuer = _configuration.GetSection("JWT:Issuer").Value,
			Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}
