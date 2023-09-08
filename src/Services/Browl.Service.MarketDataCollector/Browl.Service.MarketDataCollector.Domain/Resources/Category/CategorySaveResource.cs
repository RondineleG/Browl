using System.ComponentModel.DataAnnotations;

namespace Browl.Service.MarketDataCollector.Domain.Resources.Category;

public record CategorySaveResource
{
	[Required]
	[MaxLength(30)]
	public required string Name { get; init; }
}