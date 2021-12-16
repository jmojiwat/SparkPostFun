namespace SparkPostFun.Analytics;

public record BounceReasonMetricsByDomainResponse
{
    public IList<BounceReasonMetricsByDomainResponseResult> Results { get; init; } = new List<BounceReasonMetricsByDomainResponseResult>();
}