﻿namespace Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

public class TelephoneViewResource : ICloneable
{
<<<<<<< HEAD
	public int Id { get; set; }
	public required string Numero { get; set; }

	public object Clone() => MemberwiseClone();
=======
    public int Id { get; set; }
    public string Numero { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
>>>>>>> dev
}