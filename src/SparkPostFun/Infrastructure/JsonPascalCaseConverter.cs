using System.Text.Json;
using System.Text.Json.Serialization;
using System;

namespace SparkPostFun.Infrastructure
{
    public class JsonPascalCaseConverter<T> : JsonConverter<T> where T : struct, Enum
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString().PascalCase();

            if(!Enum.TryParse(value, out T result) && !Enum.TryParse(value, true, out result))
            {
                throw new JsonException();
            }
            
            return result;
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}