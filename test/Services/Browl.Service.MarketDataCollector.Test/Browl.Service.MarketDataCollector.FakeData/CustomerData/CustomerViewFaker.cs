using Bogus.Extensions.Brazil;

using Browl.Service.MarketDataCollector.Domain.Entities;
using Browl.Service.MarketDataCollector.FakeData.AddressData;
using Browl.Service.MarketDataCollector.FakeData.TelephoneData;

namespace Browl.Service.MarketDataCollector.FakeData.CustomerData;

public class CustomerViewFaker : Faker<Customer>
{
	public CustomerViewFaker()
	{
		var id = new Faker().Random.Number(1, 999999);
		_ = RuleFor(p => p.Id,
			_ => id);
		_ = RuleFor(p => p.Nome, f => f.Person.FullName);
		_ = RuleFor(p => p.Sexo, f => f.PickRandom<Gender>());
		_ = RuleFor(p => p.Documento, f => f.Person.Cpf());
		_ = RuleFor(p => p.Criacao, f => f.Date.Past());
		_ = RuleFor(p => p.UltimaAtualizacao, f => f.Date.Past());
		_ = RuleFor(p => p.DataNascimento, f => f.Date.Past());
		_ = RuleFor(p => p.Telefones, _ => new TelephoneViewFaker().Generate(3));
		_ = RuleFor(p => p.Endereco, _ => new AddressViewFaker().Generate());
	}
}