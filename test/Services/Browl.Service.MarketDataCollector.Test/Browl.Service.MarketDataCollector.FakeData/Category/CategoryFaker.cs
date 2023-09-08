namespace Browl.Service.MarketDataCollector.FakeData.Category;

public class CategoryFaker : Faker<Category>
{
	public CategoryFaker()
	{
		int id = new Faker().Random.Number(1, 999999);
		RuleFor(o => o.Id, _ => id);
		RuleFor(o => o.Name, f => f.Random.Word());
	}
}