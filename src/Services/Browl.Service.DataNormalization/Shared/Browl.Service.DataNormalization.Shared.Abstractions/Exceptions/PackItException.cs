using System;

namespace Browl.Service.DataNormalization.Shared.Abstractions.Exceptions
{
    public abstract class PackItException : Exception
    {
        protected PackItException(string message) : base(message)
        {
        }
    }
}