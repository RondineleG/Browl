using System;
using Browl.Service.DataNormalization.Application.DTO;
using Browl.Service.DataNormalization.Shared.Abstractions.Queries;

namespace Browl.Service.DataNormalization.Application.Queries
{
    public class GetPackingList : IQuery<PackingListDto>
    {
        public Guid Id { get; set; }
    }
}