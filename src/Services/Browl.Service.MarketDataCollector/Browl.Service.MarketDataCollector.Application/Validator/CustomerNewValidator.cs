using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
<<<<<<< HEAD

=======
>>>>>>> dev
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class CustomerNewValidator : AbstractValidator<CustomerResource>
{
<<<<<<< HEAD
	public CustomerNewValidator()
	{
		_ = RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
		_ = RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
		_ = RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
		_ = RuleFor(x => x.Telefones).NotNull().NotEmpty();
		_ = RuleFor(x => x.Sexo).NotNull();
		_ = RuleFor(x => x.Endereco).SetValidator(new AddressNewValidator());
	}
=======
    public CustomerNewValidator()
    {
        RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
        RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Telefones).NotNull().NotEmpty();
        RuleFor(x => x.Sexo).NotNull();
        RuleFor(x => x.Endereco).SetValidator(new AddressNewValidator());
    }
>>>>>>> dev
}