using System.Collections.Generic;
using Browl.Service.DataNormalization.Application.DTO;
using Browl.Service.DataNormalization.Shared.Abstractions.Queries;

namespace Browl.Service.DataNormalization.Application.Queries
{
    public class SearchPackingLists : IQuery<IEnumerable<PackingListDto>>
    {
        public string SearchPhrase { get; set; }
    }
}