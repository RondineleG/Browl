using Browl.Domain.Commands.Login;

using FluentValidation;

namespace Browl.Service.Validators.Login
{
	internal class AuthenticationValidator : AbstractValidator<AutenticationCommand>
    {
		public AuthenticationValidator() { 
			RuleFor(c => c.Email)
				.NotEmpty()				
				.WithMessage("Obrigatório informar o email");

			RuleFor(c => c.Password)
				.NotEmpty()
				.WithMessage("Não informou a senha");
		}
    }

}
