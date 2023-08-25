using Browl.Core.Interfaces.Repositories;
using Browl.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Browl.Data.Repository;

public class EspecialidadeRepository : IEspecialidadeRepository
{
    private readonly BrowlDbContext _browlDbContext;

    public EspecialidadeRepository(BrowlDbContext browlDbContext)
    {
        _browlDbContext = browlDbContext;
    }

    public async Task<bool> ExisteAsync(int id)
    {
        return await _browlDbContext.Especialidades.AnyAsync(p => p.Id == id);
    }
}