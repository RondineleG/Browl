namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Telefone
{
    public int ClienteId { get; set; }
    public string Numero { get; set; }
    public Cliente Cliente { get; set; }
}