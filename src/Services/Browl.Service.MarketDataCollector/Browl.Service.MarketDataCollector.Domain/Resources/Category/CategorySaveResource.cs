using System.ComponentModel.DataAnnotations;

namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record CategorySaveResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; init; }
    }
}