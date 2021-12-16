namespace SparkPostFun.Analytics;

public record MetricsBySendingIpResponse
{
    public IList<MetricsBySendingIpResponseResult> Results { get; init; } = new List<MetricsBySendingIpResponseResult>();
}