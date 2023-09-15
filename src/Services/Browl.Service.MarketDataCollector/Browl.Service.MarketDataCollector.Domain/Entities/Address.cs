namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Address
{
	public int ClienteId { get; set; }
	public int CEP { get; set; }
	public State Estado { get; set; }
	public required string Cidade { get; set; }
	public required string Logradouro { get; set; }
	public required string Numero { get; set; }
	public required string Complemento { get; set; }
	public required Customer Cliente { get; set; }
}
