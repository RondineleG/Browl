namespace Browl.Service.MarketDataCollector.Domain.Resources.Address;

public class AddressViewResource : ICloneable
{
<<<<<<< HEAD
	public int CEP { get; set; }
	public StateViewResource Estado { get; set; }
	public required string Cidade { get; set; }
	public required string Logradouro { get; set; }
	public required string Numero { get; set; }
	public required string Complemento { get; set; }

	public object Clone() => MemberwiseClone();
=======
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
>>>>>>> dev
}