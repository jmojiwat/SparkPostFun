namespace SparkPostFun.Analytics;

public record MetricsSummaryResponse
{
    public IList<MetricsSummaryResponseResult> Results { get; init; } = new List<MetricsSummaryResponseResult>();
    public IList<Link> Links { get; init; } = new List<Link>();
}