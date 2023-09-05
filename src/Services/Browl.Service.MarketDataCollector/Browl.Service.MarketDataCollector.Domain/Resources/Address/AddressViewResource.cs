namespace Browl.Service.MarketDataCollector.Domain.Resources.Address;

public class AddressViewResource : ICloneable
{
    public int CEP { get; set; }
    public StateViewResource Estado { get; set; }
    public string Cidade { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}