using Browl.Service.AuthSecurity.Application.Contracts.Persistence;
using Browl.Service.AuthSecurity.Domain.Common;
using Browl.Service.AuthSecurity.Persistence.DatabaseContext;

using Microsoft.EntityFrameworkCore;

namespace Browl.Service.AuthSecurity.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	protected readonly HrDatabaseContext _context;

	public GenericRepository(HrDatabaseContext context) => _context = context;

	public async Task CreateAsync(T entity)
	{
		_ = await _context.AddAsync(entity);
		_ = await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(T entity)
	{
		_ = _context.Remove(entity);
		_ = await _context.SaveChangesAsync();
	}

	public async Task<IReadOnlyList<T>> GetAsync() => await _context.Set<T>().AsNoTracking().ToListAsync();

	public async Task<T> GetByIdAsync(int id) => await _context.Set<T>()
			.AsNoTracking()
			.FirstOrDefaultAsync(q => q.Id == id);

	public async Task UpdateAsync(T entity)
	{
		_context.Entry(entity).State = EntityState.Modified;
		_ = await _context.SaveChangesAsync();
	}
}
