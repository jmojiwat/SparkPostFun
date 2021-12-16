namespace SparkPostFun.Analytics;

public record MetricsByMailboxProviderRegionResponse
{
    public IList<MetricsByMailboxProviderRegionResponseResult> Results { get; init; } = new List<MetricsByMailboxProviderRegionResponseResult>();
}