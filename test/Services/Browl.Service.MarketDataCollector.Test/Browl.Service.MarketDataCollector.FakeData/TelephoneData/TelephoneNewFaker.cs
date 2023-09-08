using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.TelephoneData;

public class TelephoneNewFaker : Faker<Telephone>
{
	public TelephoneNewFaker()
	{
		_ = RuleFor(p => p.Numero, f => f.Person.Phone);
	}
}