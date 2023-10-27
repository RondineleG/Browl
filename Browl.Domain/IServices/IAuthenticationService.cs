using Browl.Domain.Commands.Login;
using Browl.Domain.ViewModels.Login;

namespace Browl.Domain.IServices;
public interface IAuthenticationService
{
	Task<AuthenticationVM> Authenticate(AutenticationCommand command);


}
