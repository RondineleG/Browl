using Browl.Service.MarketDataCollector.Domain.Queries.Base;
<<<<<<< HEAD
=======

namespace Browl.Service.MarketDataCollector.Domain.Queries
{
    public class ProductsQuery : Query
    {
        public int? CategoryId { get; set; }
>>>>>>> dev

namespace Browl.Service.MarketDataCollector.Domain.Queries;

public class ProductsQuery : Query
{
	public int? CategoryId { get; set; }

	public ProductsQuery(int? categoryId, int page, int itemsPerPage) : base(page, itemsPerPage) => CategoryId = categoryId;
}