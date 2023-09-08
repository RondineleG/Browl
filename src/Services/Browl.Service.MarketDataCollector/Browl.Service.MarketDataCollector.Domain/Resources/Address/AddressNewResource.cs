namespace Browl.Service.MarketDataCollector.Domain.Resources.Address;

public class AddressNewResource
{
	///<example>49000000</example>
	public int CEP { get; set; }

	public StateViewResource Estado { get; set; }

	///<example>Aracaju</example>
	public required string Cidade { get; set; }

	///<example>Rua A</example>
	public required string Logradouro { get; set; }

	///<example>15</example>
	public required string Numero { get; set; }

	///<example>Ao lado do posto</example>
	public required string Complemento { get; set; }
}