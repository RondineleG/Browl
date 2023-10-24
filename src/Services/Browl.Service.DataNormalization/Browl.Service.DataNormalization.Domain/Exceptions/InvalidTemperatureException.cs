using Browl.Service.DataNormalization.Shared.Abstractions.Exceptions;

namespace Browl.Service.DataNormalization.Domain.Exceptions
{
    public class InvalidTemperatureException : PackItException
    {
        public double Value { get; }

        public InvalidTemperatureException(double value) : base($"Value '{value}' is invalid temperature.")
            => Value = value;
    }
}