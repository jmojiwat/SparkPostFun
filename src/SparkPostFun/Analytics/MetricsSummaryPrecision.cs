using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public enum MetricsSummaryPrecision
{
    [JsonPropertyName("1min")]
    OneMinute,
    [JsonPropertyName("5min")]
    FiveMinutes,
    [JsonPropertyName("15min")]
    FifteenMinutes,
    Hour,
    Day
}