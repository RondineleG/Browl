using System.Collections.Generic;
using Browl.Service.DataNormalization.Domain.ValueObjects;

namespace Browl.Service.DataNormalization.Domain.Policies
{
    public interface IPackingItemsPolicy
    {
        bool IsApplicable(PolicyData data);
        IEnumerable<PackingItem> GenerateItems(PolicyData data);
    }
}