

using Browl.Domain.Commands.Login;
using FluentValidation;

namespace Browl.Service.Validators.Login;
internal class CreateUserValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserValidator()
	{
		RuleFor(c => c.Email)
			.NotEmpty()
			.WithMessage("Obrigatório informar o email");

		RuleFor(c => c.Password)
			.NotEmpty()
			.WithMessage("Não informou a senha");

		RuleFor(c => c.Nome)
			.NotEmpty()
			.WithMessage("Não informou o Nome");
	}
}
