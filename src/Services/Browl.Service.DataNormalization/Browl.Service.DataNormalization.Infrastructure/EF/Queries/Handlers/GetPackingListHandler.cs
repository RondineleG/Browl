using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Browl.Service.DataNormalization.Application.DTO;
using Browl.Service.DataNormalization.Application.Queries;
using Browl.Service.DataNormalization.Infrastructure.EF.Contexts;
using Browl.Service.DataNormalization.Infrastructure.EF.Models;
using Browl.Service.DataNormalization.Shared.Abstractions.Queries;

namespace Browl.Service.DataNormalization.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetPackingListHandler : IQueryHandler<GetPackingList, PackingListDto>
    {
        private readonly DbSet<PackingListReadModel> _packingLists;

        public GetPackingListHandler(ReadDbContext context)
            => _packingLists = context.PackingLists;

        public Task<PackingListDto> HandleAsync(GetPackingList query)
            => _packingLists
                .Include(pl => pl.Items)
                .Where(pl => pl.Id == query.Id)
                .Select(pl => pl.AsDto())
                .AsNoTracking()
                .SingleOrDefaultAsync();
    }
}