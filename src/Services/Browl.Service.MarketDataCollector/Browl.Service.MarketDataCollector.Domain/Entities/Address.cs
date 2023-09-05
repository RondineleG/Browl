namespace Browl.Service.MarketDataCollector.Domain.Entities;
public class Address
{
    public int ClienteId { get; set; }
    public int CEP { get; set; }
    public State Estado { get; set; }
    public string Cidade { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public Customer Cliente { get; set; }
}