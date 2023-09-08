using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.Domain.Resources.Category;

namespace Browl.Service.MarketDataCollector.Application.Test.Builders;

public class CategoryResourceBuilder
{
	private readonly int _id = 1;
	private string _name = "My new Category";
	public Category Build() => new(BuildResource());

	public CategoryResource BuildResource() => new()
	{
		Id = _id,
		Name = _name
	};

	public CategoryResourceBuilder WithName(string name)
	{
		_name = name;
		return this;
	}
}
