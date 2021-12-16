namespace SparkPostFun.Analytics;

public record MetricsByMailboxProviderResponse
{
    public IList<MetricsByMailboxProviderResponseResult> Results { get; init; } = new List<MetricsByMailboxProviderResponseResult>();
}