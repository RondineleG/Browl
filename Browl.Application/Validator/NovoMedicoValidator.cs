using Browl.Core.Dtos.Medico;
using Browl.Core.Interfaces.Repositories;
using FluentValidation;

namespace Browl.Application.Validator;

public class NovoMedicoValidator : AbstractValidator<NovoMedico>
{
    public NovoMedicoValidator(IEspecialidadeRepository repository)
    {
        RuleFor(p => p.Nome).NotNull().NotEmpty().MaximumLength(200);

        RuleFor(p => p.CRM).NotNull().NotEmpty().GreaterThan(0);

        RuleForEach(p => p.Especialidades).SetValidator(new ReferenciaEspecialidadeValidator(repository));
    }
}