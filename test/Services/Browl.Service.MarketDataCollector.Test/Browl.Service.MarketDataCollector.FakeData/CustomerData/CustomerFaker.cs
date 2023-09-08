using Bogus.Extensions.Brazil;
using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.FakeData.AddressData;
using Browl.Service.MarketDataCollector.FakeData.TelephoneData;

namespace Browl.Service.MarketDataCollector.FakeData.CustomerData;

public class CustomerFaker : Faker<Customer>
{
	public CustomerFaker()
	{
		int id = new Faker().Random.Number(1, 999999);
		_ = RuleFor(o => o.Id, _ => id);
		_ = RuleFor(o => o.Nome, f => f.Person.FullName);
		_ = RuleFor(o => o.Sexo, f => f.PickRandom<Gender>());
		_ = RuleFor(o => o.Documento, f => f.Person.Cpf());
		_ = RuleFor(o => o.Criacao, f => f.Date.Past());
		_ = RuleFor(o => o.UltimaAtualizacao, f => f.Date.Past());
		_ = RuleFor(o => o.Telefones, _ => new TelephoneFaker(id).Generate(3));
		_ = RuleFor(o => o.Endereco, _ => new AddressFaker(id).Generate());
	}
}