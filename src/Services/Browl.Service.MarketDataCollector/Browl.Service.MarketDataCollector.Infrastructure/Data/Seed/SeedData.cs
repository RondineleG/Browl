using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Enums;
using Browl.Service.MarketDataCollector.Infrastructure.Data.Contexts;

namespace Browl.Service.MarketDataCollector.Infrastructure.Data.Seed
{
	public static class SeedData
	{
		public static async Task Seed(BrowlDbContext context)
		{
			List<Product> products = new()
			{
				new Product
				{
					Id = 100,
					Name = "Apple",
					QuantityInPackage = 1,
					UnitOfMeasurement = UnitOfMeasurement.Unity,
					CategoryId = 100
				},
				new Product
				{
					Id = 101,
					Name = "Milk",
					QuantityInPackage = 2,
					UnitOfMeasurement = UnitOfMeasurement.Liter,
					CategoryId = 101,
				}
			};

			List<Category> categories = new()
			{
				new Category(100, "Fruits and Vegetables" ),
				new Category(101,"Dairy" )
			};

			context.Products.AddRange(products);
			context.Categories.AddRange(categories);

			_ = await context.SaveChangesAsync();
		}
	}
}