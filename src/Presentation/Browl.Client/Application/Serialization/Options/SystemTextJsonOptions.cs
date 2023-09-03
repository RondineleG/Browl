using System.Text.Json;
using Browl.Application.Interfaces.Serialization.Options;

namespace Browl.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}