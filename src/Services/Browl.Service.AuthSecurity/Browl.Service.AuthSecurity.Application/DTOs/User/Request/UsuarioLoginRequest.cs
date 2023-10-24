using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.Application.DTOs.User.Request;

public class UsuarioLoginRequest
{
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[EmailAddress(ErrorMessage = "O campo {0} é inválido")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	public required string Senha { get; set; }
}