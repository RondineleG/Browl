using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class CustomerNewValidator : AbstractValidator<CustomerResource>
{
	public CustomerNewValidator()
	{
		_ = RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
		_ = RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
		_ = RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
		_ = RuleFor(x => x.Telefones).NotNull().NotEmpty();
		_ = RuleFor(x => x.Sexo).NotNull();
		_ = RuleFor(x => x.Endereco).SetValidator(new AddressNewValidator());
	}
}