namespace SparkPostFun.Analytics;

public record DiscoverabilityLinksResponseResult
{
    public string Schema { get; init; }
    public string Id { get; init; }
    public string Type { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    public object Default { get; init; } = new();
    public IDictionary<string, object> Required { get; init; }
    public object Properties { get; init; } = new();
    public bool AdditionalProperties { get; init; }
    public Defs Defs { get; init; } = new();
}