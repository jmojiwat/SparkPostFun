namespace SparkPostFun.Analytics;

public record DomainsMetricsResponseResult
{
    public IList<string> Domains { get; init; } = new List<string>();
}