using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Browl.Service.DataNormalization.Application.Services;
using Browl.Service.DataNormalization.Infrastructure.EF.Contexts;
using Browl.Service.DataNormalization.Infrastructure.EF.Models;

namespace Browl.Service.DataNormalization.Infrastructure.EF.Services
{
    internal sealed class PostgresPackingListReadService : IPackingListReadService
    {
        private readonly DbSet<PackingListReadModel> _packingList;

        public PostgresPackingListReadService(ReadDbContext context)
            => _packingList = context.PackingLists;

        public Task<bool> ExistsByNameAsync(string name)
            => _packingList.AnyAsync(pl => pl.Name == name);
    }
}