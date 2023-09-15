using Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class TelephoneNewValidator : AbstractValidator<TelephoneNewResource>
{
	public TelephoneNewValidator() => _ = RuleFor(p => p.Numero).Matches("[1-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
}
