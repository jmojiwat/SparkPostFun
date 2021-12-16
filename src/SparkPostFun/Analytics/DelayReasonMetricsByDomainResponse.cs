namespace SparkPostFun.Analytics;

public record DelayReasonMetricsByDomainResponse
{
    public IList<DelayReasonMetricsByDomainResponseResult> Results { get; init; } = new List<DelayReasonMetricsByDomainResponseResult>();
}