using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;
<<<<<<< HEAD

=======
>>>>>>> dev
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class TelephoneNewValidator : AbstractValidator<TelephoneNewResource>
{
<<<<<<< HEAD
	public TelephoneNewValidator() => _ = RuleFor(p => p.Numero).Matches("[1-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
=======
    public TelephoneNewValidator()
    {
        RuleFor(p => p.Numero).Matches("[1-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
    }
>>>>>>> dev
}