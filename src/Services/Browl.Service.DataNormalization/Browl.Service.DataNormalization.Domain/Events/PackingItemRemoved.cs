using Browl.Service.DataNormalization.Domain.Entities;
using Browl.Service.DataNormalization.Domain.ValueObjects;
using Browl.Service.DataNormalization.Shared.Abstractions.Domain;

namespace Browl.Service.DataNormalization.Domain.Events
{
    public record PackingItemRemoved(PackingList PackingList, PackingItem PackingItem) : IDomainEvent;
}