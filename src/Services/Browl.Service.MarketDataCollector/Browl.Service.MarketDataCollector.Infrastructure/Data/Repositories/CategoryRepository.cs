using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
	public CategoryRepository(BrowlServiceMarketDataCollectorDbContext context) : base(context) { }

	public async Task<IEnumerable<Category>> ListAsync() => await _browlDbContext.Categories.AsNoTracking().ToListAsync();

	public async Task AddAsync(Category category) => _ = await _browlDbContext.Categories.AddAsync(category);

	public async Task<Category> FindByIdAsync(int id) => await _browlDbContext.Categories.FindAsync(id);

	public void Update(Category category) => _ = _browlDbContext.Categories.Update(category);

	public void Remove(Category category) => _ = _browlDbContext.Categories.Remove(category);
}