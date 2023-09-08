using System.ComponentModel;

namespace Browl.Service.MarketDataCollector.Domain.Enums
{
	public enum UnitOfMeasurement : byte
	{
		[Description("UN")]
		Unity = 1,

		[Description("MG")]
		Milligram = 2,

		[Description("G")]
		Gram = 3,

		[Description("KG")]
		Kilogram = 4,

		[Description("L")]
		Liter = 5
	}
}