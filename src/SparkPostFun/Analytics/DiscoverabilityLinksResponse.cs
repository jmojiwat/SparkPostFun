namespace SparkPostFun.Analytics;

public record DiscoverabilityLinksResponse
{
    public object Results { get; init; } = new();
    public IList<Link> Links { get; init; } = new List<Link>();
}