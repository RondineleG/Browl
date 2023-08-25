namespace Browl.Core.Interfaces.Repositories;

public interface IEspecialidadeRepository
{
    Task<bool> ExisteAsync(int id);
}