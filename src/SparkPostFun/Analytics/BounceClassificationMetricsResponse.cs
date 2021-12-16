namespace SparkPostFun.Analytics;

public record BounceClassificationMetricsResponse
{
    public IList<BounceClassificationMetricsResponseResult> Results { get; init; } = new List<BounceClassificationMetricsResponseResult>();
}