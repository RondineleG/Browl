﻿using Browl.Core.Entities;
using Browl.Core.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Browl.Data.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration configuration;

    public JwtService(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public string GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Login)
            };
        claims.AddRange(usuario.Funcoes.Select(p => new Claim(ClaimTypes.Role, p.Descricao)));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Audience = configuration.GetSection("JWT:Audience").Value,
            Issuer = configuration.GetSection("JWT:Issuer").Value,
            Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}