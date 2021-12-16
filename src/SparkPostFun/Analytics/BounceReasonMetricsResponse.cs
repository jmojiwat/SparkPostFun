namespace SparkPostFun.Analytics;

public record BounceReasonMetricsResponse
{
    public IList<BounceReasonMetricsResponseResult> Results { get; init; } = new List<BounceReasonMetricsResponseResult>();
}