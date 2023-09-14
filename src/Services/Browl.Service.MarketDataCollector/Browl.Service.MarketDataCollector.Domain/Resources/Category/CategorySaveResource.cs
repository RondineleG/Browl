using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace Browl.Service.MarketDataCollector.Domain.Resources.Category;

public record CategorySaveResource
{
	[Required]
	[MaxLength(30)]
	public required string Name { get; init; }
=======
namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record CategorySaveResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; init; }
    }
>>>>>>> dev
}