using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.CategoryData;

public class CategoryFaker : Faker<Category>
{
	public CategoryFaker()
	{
		var id = new Faker().Random.Number(1, 999999);
		var unused1 = RuleFor(o => o.Id, _ => id);
		var unused = RuleFor(o => o.Name, f => f.Random.Word());
	}
}