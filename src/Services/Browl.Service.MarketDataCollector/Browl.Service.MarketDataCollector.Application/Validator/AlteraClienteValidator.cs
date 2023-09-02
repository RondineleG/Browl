using Browl.Service.MarketDataCollector.Domain.Dtos.Cliente;
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
{
    public AlteraClienteValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoClienteValidator());
    }
}