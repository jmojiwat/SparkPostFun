namespace SparkPostFun.Analytics;

public record DiscoverabilityLinksResponse
{
    public object Results { get; init; } = new();
    public IList<DiscoverabilityLink> Links { get; init; } = new List<DiscoverabilityLink>();
}