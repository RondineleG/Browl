using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.TelephoneData;

public class TelephoneFaker : Faker<Telephone>
{
	public TelephoneFaker(int clientId)
	{
		_ = RuleFor(o => o.ClienteId, _ => clientId);
		_ = RuleFor(o => o.Numero, f => f.Person.Phone);
	}
}