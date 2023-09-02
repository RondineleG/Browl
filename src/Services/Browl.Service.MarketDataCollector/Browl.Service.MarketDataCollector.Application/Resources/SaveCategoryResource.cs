using System.ComponentModel.DataAnnotations;

namespace Browl.Service.MarketDataCollector.Application.Resources
{
    public record SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; init; }
    }
}