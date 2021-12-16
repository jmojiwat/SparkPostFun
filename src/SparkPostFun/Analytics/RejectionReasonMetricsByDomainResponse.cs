namespace SparkPostFun.Analytics;

public record RejectionReasonMetricsByDomainResponse
{
    public IList<RejectionReasonMetricsByDomainResponseResult> Results { get; init; } = new List<RejectionReasonMetricsByDomainResponseResult>();
}