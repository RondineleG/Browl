﻿using Browl.Service.MarketDataCollector.Domain.Resources.Customer;
using FluentValidation;

namespace Browl.Service.MarketDataCollector.Application.Validator;

public class NovoClienteValidator : AbstractValidator<CustomerResource>
{
    public NovoClienteValidator()
    {
        RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(10).MaximumLength(150);
        RuleFor(x => x.DataNascimento).NotNull().NotEmpty().LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
        RuleFor(x => x.Documento).NotNull().NotEmpty().MinimumLength(4).MaximumLength(14);
        RuleFor(x => x.Telefones).NotNull().NotEmpty();
        RuleFor(x => x.Sexo).NotNull();
        RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
    }
}