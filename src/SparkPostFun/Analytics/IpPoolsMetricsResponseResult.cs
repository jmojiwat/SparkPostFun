namespace SparkPostFun.Analytics;

public record IpPoolsMetricsResponseResult
{
    public IList<string> IpPools { get; init; } = new List<string>();
}