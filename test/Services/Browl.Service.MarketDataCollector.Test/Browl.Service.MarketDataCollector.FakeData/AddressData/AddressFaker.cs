using Browl.Service.MarketDataCollector.Domain.Entities;

namespace Browl.Service.MarketDataCollector.FakeData.AddressData;

public class AddressFaker : Faker<Address>
{
	public AddressFaker(int clientId)
	{
		_ = RuleFor(o => o.ClienteId, _ => clientId);
		_ = RuleFor(o => o.Numero, f => f.Address.BuildingNumber());
		_ = RuleFor(o => o.CEP, f => Convert.ToInt32(f.Address.ZipCode().Replace("-", "")));
		_ = RuleFor(o => o.Cidade, f => f.Address.City());
		_ = RuleFor(o => o.Estado, f => f.PickRandom<State>());
		_ = RuleFor(o => o.Logradouro, f => f.Address.StreetName());
		_ = RuleFor(o => o.Complemento, f => f.Lorem.Sentence(10));
	}
}