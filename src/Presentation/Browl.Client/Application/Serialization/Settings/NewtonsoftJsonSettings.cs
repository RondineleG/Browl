
using Browl.Application.Interfaces.Serialization.Settings;
using Newtonsoft.Json;

namespace Browl.Application.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}