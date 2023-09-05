using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class AlteraClienteValidator : AbstractValidator<CustomerUpdateResource>
{
    public AlteraClienteValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoClienteValidator());
    }
}