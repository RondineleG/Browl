using Browl.Service.DataNormalization.Shared.Abstractions.Exceptions;

namespace Browl.Service.DataNormalization.Domain.Exceptions
{
    public class EmptyPackingListNameException : PackItException
    {
        public EmptyPackingListNameException() : base("packing list name cannot be empty.")
        {
        }
    }
}