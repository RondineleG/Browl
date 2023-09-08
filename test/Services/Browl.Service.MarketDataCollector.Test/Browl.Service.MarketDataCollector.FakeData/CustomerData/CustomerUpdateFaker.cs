using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.FakeData.AddressData;
using Browl.Service.MarketDataCollector.FakeData.TelephoneData;

namespace Browl.Service.MarketDataCollector.FakeData.CustomerData;

public class CustomerUpdateFaker : Faker<Customer>
{
	public CustomerUpdateFaker()
	{
		var id = new Faker().Random.Number(1, 100);
		_ = RuleFor(o => o.Id, _ => id);
		_ = RuleFor(o => o.Nome, f => f.Person.FullName);
		_ = RuleFor(o => o.Sexo, f => f.PickRandom<Gender>());
		_ = RuleFor(o => o.Telefones, _ => new TelephoneNewFaker().Generate(3));
		_ = RuleFor(o => o.Endereco, _ => new AddressNewFaker().Generate());
	}
}