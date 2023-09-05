namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Telephone
{
    public int ClienteId { get; set; }
    public string Numero { get; set; }
    public Customer Cliente { get; set; }
}