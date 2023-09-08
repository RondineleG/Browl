using Browl.Service.MarketDataCollector.Domain.Resources.Category;

namespace Browl.Service.MarketDataCollector.Domain.Entities;

public class Category
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public List<Product> Products { get; set; } = new();

	protected Category() { }

	public Category(CategoryResource categoryResource)
	{
		Id = categoryResource.Id;
		Name = categoryResource.Name;
	}

	public Category(int id, string name)
	{
		Id = id;
		Name = name;
	}
}