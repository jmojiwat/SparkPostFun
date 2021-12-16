using System.Text.Json;
using System.Text.Json.Serialization;

namespace SparkPostFun.Infrastructure
{
    public static class JsonSerializerOptionsExtensions
    {
        public static JsonSerializerOptions DefaultJsonSerializerOptions()
        {
            var jsonSnakeCaseNamingPolicy = new JsonSnakeCaseNamingPolicy();
            return new JsonSerializerOptions
            {
                PropertyNamingPolicy = jsonSnakeCaseNamingPolicy,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter(jsonSnakeCaseNamingPolicy) }, 
                
            };
        }
    }
}