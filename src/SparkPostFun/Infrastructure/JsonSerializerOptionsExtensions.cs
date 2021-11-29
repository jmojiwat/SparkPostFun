using System.Text.Json;
using System.Text.Json.Serialization;

namespace SparkPostFun.Infrastructure
{
    public static class JsonSerializerOptionsExtensions
    {
        public static JsonSerializerOptions DefaultJsonSerializerOptions() => new JsonSerializerOptions()
        {
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };
    }
}