using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
<<<<<<< HEAD

=======
>>>>>>> dev
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateResource>
{
<<<<<<< HEAD
	public CustomerUpdateValidator()
	{
		_ = RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
		Include(new CustomerNewValidator());
	}
=======
    public CustomerUpdateValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new CustomerNewValidator());
    }
>>>>>>> dev
}