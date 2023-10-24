using System;
using Browl.Service.DataNormalization.Shared.Abstractions.Exceptions;

namespace Browl.Service.DataNormalization.Application.Exceptions
{
    public class PackingListNotFoundException : PackItException
    {
        public Guid Id { get; }

        public PackingListNotFoundException(Guid id) : base($"Packing list with ID '{id}' was not found.")
            => Id = id;
    }
}