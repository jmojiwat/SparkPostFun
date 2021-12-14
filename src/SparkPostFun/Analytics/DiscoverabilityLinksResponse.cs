namespace SparkPostFun.Analytics;

public record DiscoverabilityLinksResponse
{
    public DiscoverabilityLinksResponseResult Results { get; init; } = new();
    public IList<Link> Links { get; init; } = new List<Link>();
}