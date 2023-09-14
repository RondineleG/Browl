using Browl.Service.MarketDataCollector.Domain.Resources.Address;
<<<<<<< HEAD

=======
>>>>>>> dev
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class AddressNewValidator : AbstractValidator<AddressNewResource>
{
<<<<<<< HEAD
	public AddressNewValidator()
	{
		_ = RuleFor(p => p.CEP).NotEmpty().NotNull();
		_ = RuleFor(p => p.Estado).NotNull();
		_ = RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
		_ = RuleFor(p => p.Logradouro).NotEmpty().NotNull().MaximumLength(200);
		_ = RuleFor(p => p.Numero).NotEmpty().NotNull().MaximumLength(10);
		_ = RuleFor(p => p.Complemento).MaximumLength(200);
	}
=======
    public AddressNewValidator()
    {
        RuleFor(p => p.CEP).NotEmpty().NotNull();
        RuleFor(p => p.Estado).NotNull();
        RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Logradouro).NotEmpty().NotNull().MaximumLength(200);
        RuleFor(p => p.Numero).NotEmpty().NotNull().MaximumLength(10);
        RuleFor(p => p.Complemento).MaximumLength(200);
    }
>>>>>>> dev
}