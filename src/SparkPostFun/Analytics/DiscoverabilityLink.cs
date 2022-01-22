namespace SparkPostFun.Analytics;

public record DiscoverabilityLink
{
    public string Href { get; init; }
    public string Rel { get; init; }
    public string Method { get; init; }
}