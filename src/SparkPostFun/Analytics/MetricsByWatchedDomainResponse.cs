namespace SparkPostFun.Analytics;

public record MetricsByWatchedDomainResponse
{
    public IList<MetricsByWatchedDomainResponseResult> Results { get; init; } = new List<MetricsByWatchedDomainResponseResult>();
}