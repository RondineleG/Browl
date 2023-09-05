using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class CustomerUpdateValidator : AbstractValidator<CustomerUpdateResource>
{
    public CustomerUpdateValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new CustomerNewValidator());
    }
}