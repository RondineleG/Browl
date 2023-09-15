namespace Browl.Service.MarketDataCollector.Domain.Resources.Address;

public class AddressViewResource : ICloneable
{
	public int CEP { get; set; }
	public StateViewResource Estado { get; set; }
	public required string Cidade { get; set; }
	public required string Logradouro { get; set; }
	public required string Numero { get; set; }
	public required string Complemento { get; set; }

	public object Clone() => MemberwiseClone();
}
