using Browl.Core.Dtos.Cliente;
using FluentValidation;

namespace Browl.Application.Validator;

public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
{
    public AlteraClienteValidator()
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoClienteValidator());
    }
}