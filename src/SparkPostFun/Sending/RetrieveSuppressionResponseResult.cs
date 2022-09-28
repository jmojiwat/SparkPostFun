using System.Text.Json.Serialization;
using System;
using SparkPostFun.Infrastructure;

namespace SparkPostFun.Sending
{
    public record RetrieveSuppressionResponseResult
    {
        public string Recipient { get; init; }

        [JsonConverter(typeof(JsonPascalCaseConverter<SuppressionType>))]
        public SuppressionType Type { get; init; }

        public string Source { get; init; }
        public string Description { get; init; }
        public DateTimeOffset Created { get; init; }
        public DateTimeOffset Updated { get; init; }
    }
}