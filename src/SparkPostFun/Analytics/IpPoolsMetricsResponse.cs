namespace SparkPostFun.Analytics;

public record IpPoolsMetricsResponse
{
    public IpPoolsMetricsResponseResult Results { get; init; } = new();
}