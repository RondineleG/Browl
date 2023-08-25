using Browl.Core.Dtos.Medico;
using Browl.Core.Interfaces.Repositories;
using FluentValidation;

namespace Browl.Application.Validator;

public class AlteraMedicoValidator : AbstractValidator<AlteraMedico>
{
    public AlteraMedicoValidator(IEspecialidadeRepository repository)
    {
        RuleFor(p => p.Id).NotNull().NotEmpty().GreaterThan(0);
        Include(new NovoMedicoValidator(repository));
    }
}