namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Telephone
{
	public int ClienteId { get; set; }
	public required string Numero { get; set; }
	public required Customer Cliente { get; set; }
	public int Id { get; set; }
}
