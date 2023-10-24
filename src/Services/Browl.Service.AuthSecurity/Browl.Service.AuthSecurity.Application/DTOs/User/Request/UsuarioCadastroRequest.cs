using System.ComponentModel.DataAnnotations;

namespace Browl.Service.AuthSecurity.Application.DTOs.User.Request;

public class UsuarioCadastroRequest
{
	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[EmailAddress(ErrorMessage = "O campo {0} é inválido")]
	public required string Email { get; set; }

	[Required(ErrorMessage = "O campo {0} é obrigatório")]
	[StringLength(50, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres", MinimumLength = 6)]
	public required string Senha { get; set; }

	[Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
	public required string SenhaConfirmacao { get; set; }
}