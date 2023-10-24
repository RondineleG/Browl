using Browl.Service.DataNormalization.Shared.Abstractions.Exceptions;

namespace Browl.Service.DataNormalization.Domain.Exceptions
{
    public class EmptyPackingListIdException : PackItException
    {
        public EmptyPackingListIdException() : base("Packing list ID cannot be empty.")
        {
        }
    }
}