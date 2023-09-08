using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.AddressData;

public class AddressViewFaker : Faker<Address>
{
	public AddressViewFaker()
	{
		_ = RuleFor(p => p.Numero, f => f.Address.BuildingNumber());
		_ = RuleFor(p => p.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
		_ = RuleFor(p => p.Cidade, f => f.Address.City());
		_ = RuleFor(p => p.Estado, f => f.PickRandom<State>());
		_ = RuleFor(p => p.Logradouro, f => f.Address.StreetName());
		_ = RuleFor(p => p.Complemento, f => f.Lorem.Sentence(20));
	}
}