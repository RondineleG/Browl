using System.Collections.Generic;
using System.Linq;
using Browl.Service.DataNormalization.Domain.Consts;
using Browl.Service.DataNormalization.Domain.Entities;
using Browl.Service.DataNormalization.Domain.Policies;
using Browl.Service.DataNormalization.Domain.ValueObjects;

namespace Browl.Service.DataNormalization.Domain.Factories
{
    public sealed class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemsPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemsPolicy> policies)
            => _policies = policies;

        public PackingList Create(PackingListId id, PackingListName name, Localization localization)
            => new(id, name, localization);
        
        public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, TravelDays days, Gender gender,
            Temperature temperature, Localization localization)
        {
            var data = new PolicyData(days, gender, temperature, localization);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(p => p.GenerateItems(data));
            var packingList = Create(id, name, localization);
            
            packingList.AddItems(items);

            return packingList;
        }
    }
}