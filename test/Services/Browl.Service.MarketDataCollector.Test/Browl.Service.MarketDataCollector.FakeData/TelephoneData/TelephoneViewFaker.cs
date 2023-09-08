using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.TelephoneData;

public class TelephoneViewFaker : Faker<Telephone>
{
	public TelephoneViewFaker()
	{
		_ = RuleFor(p => p.Id, f => f.Random.Number(1, 10));
		_ = RuleFor(p => p.Numero, f => f.Person.Phone);
	}
}