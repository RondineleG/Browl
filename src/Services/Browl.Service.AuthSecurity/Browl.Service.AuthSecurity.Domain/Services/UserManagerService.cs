using Browl.Service.AuthSecurity.Domain.Constants;
using Browl.Service.AuthSecurity.Domain.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;

using System.Text;

namespace Browl.Service.AuthSecurity.Domain.Services;
public class UserManagerService : IUserManagerService
{
    private readonly IConfiguration _configuration;

    Dictionary<string, string> UsersRecords = new Dictionary<string, string>
    {
        { "user1","password1"},
        { "user2","password2"},
        { "user3","password3"},
    };


    public UserManagerService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Tokens Authenticate(Users users)
    {
        if (!UsersRecords.Any(x => x.Key == users.Name && x.Value == users.Password))
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
          {
             new Claim(ClaimTypes.Name, users.Name)
          }),
            Expires = DateTime.UtcNow.AddMinutes(10),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return new Tokens { Token = tokenHandler.WriteToken(token) };
    }
}
