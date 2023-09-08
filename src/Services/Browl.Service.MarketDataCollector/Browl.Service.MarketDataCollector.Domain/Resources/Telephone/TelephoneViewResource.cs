﻿namespace Browl.Service.MarketDataCollector.Domain.Resources.Telephone;

public class TelephoneViewResource : ICloneable
{
	public int Id { get; set; }
	public required string Numero { get; set; }

	public object Clone() => MemberwiseClone();
}