using Browl.Core.Dtos.Especialidade;
using Browl.Core.Interfaces.Repositories;
using FluentValidation;

namespace Browl.Application.Validator;

public class ReferenciaEspecialidadeValidator : AbstractValidator<ReferenciaEspecialidade>
{
    private readonly IEspecialidadeRepository repository;

    public ReferenciaEspecialidadeValidator(IEspecialidadeRepository repository)
    {
        this.repository = repository;
        RuleFor(p => p.Id).NotEmpty().NotNull().GreaterThan(0)
            .MustAsync(async (id, _) => await ExisteNaBase(id)).WithMessage("Especialidade não cadastrada");
    }

    private async Task<bool> ExisteNaBase(int id)
    {
        return await repository.ExisteAsync(id);
    }
}