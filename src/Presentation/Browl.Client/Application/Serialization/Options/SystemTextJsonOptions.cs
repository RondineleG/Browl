using Browl.Application.Interfaces.Serialization.Options;
using System.Text.Json;

namespace Browl.Application.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();
    }
}