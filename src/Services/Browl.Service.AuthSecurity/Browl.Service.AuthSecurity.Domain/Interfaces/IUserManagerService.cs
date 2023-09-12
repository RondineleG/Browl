using Browl.Service.AuthSecurity.Domain.Constants;

namespace Browl.Service.AuthSecurity.Domain.Interfaces;
public interface IUserManagerService
{
    Tokens Authenticate(Users users);
}
