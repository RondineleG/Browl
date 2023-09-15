using Browl.Service.MarketDataCollector.Domain.Resources.Address;

using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class AddressNewValidator : AbstractValidator<AddressNewResource>
{
	public AddressNewValidator()
	{
		_ = RuleFor(p => p.CEP).NotEmpty().NotNull();
		_ = RuleFor(p => p.Estado).NotNull();
		_ = RuleFor(p => p.Cidade).NotEmpty().NotNull().MaximumLength(200);
		_ = RuleFor(p => p.Logradouro).NotEmpty().NotNull().MaximumLength(200);
		_ = RuleFor(p => p.Numero).NotEmpty().NotNull().MaximumLength(10);
		_ = RuleFor(p => p.Complemento).MaximumLength(200);
	}
}
