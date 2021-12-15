namespace SparkPostFun.Analytics;

public record InboxRateMetricsResponse
{
    public IList<InboxRateMetricsResponseResult> Results { get; init; } = new List<InboxRateMetricsResponseResult>();
}