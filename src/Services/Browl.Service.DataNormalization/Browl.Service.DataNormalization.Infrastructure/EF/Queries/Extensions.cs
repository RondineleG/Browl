using System.Linq;
using Browl.Service.DataNormalization.Application.DTO;
using Browl.Service.DataNormalization.Infrastructure.EF.Models;

namespace Browl.Service.DataNormalization.Infrastructure.EF.Queries
{
    internal static class Extensions
    {
        public static PackingListDto AsDto(this PackingListReadModel readModel)
            => new()
            {
                Id = readModel.Id,
                Name = readModel.Name,
                Localization = new LocalizationDto
                {
                    City = readModel.Localization?.City,
                    Country = readModel.Localization?.Country
                },
                Items = readModel.Items?.Select(pi => new PackingItemDto
                {
                    Name = pi.Name,
                    Quantity = pi.Quantity,
                    IsPacked = pi.IsPacked
                })
            };
    }
}