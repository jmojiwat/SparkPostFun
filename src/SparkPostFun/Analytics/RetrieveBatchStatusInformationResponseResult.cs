using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record RetrieveBatchStatusInformationResponseResult
{
    public string BatchId { get; init; }
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; init; }
    public int Attempts { get; init; }
    public string ResponseCode { get; init; }
    public int Latency { get; init; }
}