using Browl.Service.MarketDataCollector.Domain.Resources.Customer;

using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateResource>
{
	public CustomerUpdateValidator()
	{
		_ = RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
		Include(new CustomerNewValidator());
	}
}