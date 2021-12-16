namespace SparkPostFun.Analytics;

public record MetricsByIpPoolResponse
{
    public IList<MetricsByIpPoolResponseResult> Results { get; init; } = new List<MetricsByIpPoolResponseResult>();
}