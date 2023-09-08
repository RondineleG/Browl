using Bogus.Extensions.Brazil;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.FakeData.AddressData;
using Browl.Service.MarketDataCollector.FakeData.TelephoneData;

namespace Browl.Service.MarketDataCollector.FakeData.CustomerData;

public class CustomerNewFaker : Faker<Customer>
{
	public CustomerNewFaker()
	{
		_ = RuleFor(p => p.Nome, f => f.Person.FullName);
		_ = RuleFor(p => p.Sexo, f => f.PickRandom<Gender>());
		_ = RuleFor(p => p.Documento, f => f.Person.Cpf());
		_ = RuleFor(p => p.DataNascimento, f => f.Date.Past());
		_ = RuleFor(p => p.Telefones, _ => new TelephoneNewFaker().Generate(3));
		_ = RuleFor(p => p.Endereco, _ => new AddressNewFaker().Generate());
	}
}