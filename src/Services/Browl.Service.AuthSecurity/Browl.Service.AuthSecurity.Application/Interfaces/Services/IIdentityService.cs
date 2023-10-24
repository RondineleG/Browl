using Browl.Service.AuthSecurity.Application.DTOs.User.Request;
using Browl.Service.AuthSecurity.Application.DTOs.User.Response;

namespace Browl.Service.AuthSecurity.Application.Interfaces.Services;

public interface IIdentityService
{
	Task<UsuarioCadastroResponse> CadastrarUsuarioAsync(UsuarioCadastroRequest usuarioCadastro);
	Task<UsuarioLoginResponse> LoginAsync(UsuarioLoginRequest usuarioLogin);
	Task<UsuarioLoginResponse> LoginSemSenhaAsync(string usuarioId);
}
