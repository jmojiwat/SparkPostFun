using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record InboxRateMetricsResponseResult
{
    public decimal Median { get; init; }
    public decimal Q25 { get; set; }
    public decimal Q75 { get; set; }
    [JsonPropertyName("ts")]
    public decimal Timestamp { get; set; }
}