using System;
using Browl.Service.DataNormalization.Domain.Exceptions;

namespace Browl.Service.DataNormalization.Domain.ValueObjects
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyPackingListIdException();
            }
            
            Value = value;
        }
        
        public static implicit operator Guid(PackingListId id)
            => id.Value;
        
        public static implicit operator PackingListId(Guid id)
            => new(id);
    }
}