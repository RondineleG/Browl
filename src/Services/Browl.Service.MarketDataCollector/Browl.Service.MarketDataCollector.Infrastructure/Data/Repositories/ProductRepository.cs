using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Interfaces.Repositories;
using Browl.Service.MarketDataCollector.Domain.Queries;
using Browl.Service.MarketDataCollector.Domain.Queries.Base;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(BrowlDbContext context) : base(context) { }

        public async Task<QueryResult<Product>> ListAsync(ProductsQuery query)
        {
            IQueryable<Product> queryable = _browlDbContext.Products
                                                    .Include(p => p.Category)
                                                    .AsNoTracking();

            if (query.CategoryId.HasValue && query.CategoryId > 0)
            {
                queryable = queryable.Where(p => p.CategoryId == query.CategoryId);
            }

            int totalItems = await queryable.CountAsync();

            List<Product> products = await queryable.Skip((query.Page - 1) * query.ItemsPerPage)
                                                    .Take(query.ItemsPerPage)
                                                    .ToListAsync();

            return new QueryResult<Product>
            {
                Items = products,
                TotalItems = totalItems,
            };
        }

        public async Task<Product> FindByIdAsync(int id)
        {
            return await _browlDbContext.Products
                                 .Include(p => p.Category)
                                 .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Product product)
        {
            await _browlDbContext.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _browlDbContext.Products.Update(product);
        }

        public void Remove(Product product)
        {
            _browlDbContext.Products.Remove(product);
        }
    }
}