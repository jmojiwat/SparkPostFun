namespace SparkPostFun.Analytics;

public record RejectionReasonMetricsByDomainResponseResult
{
    public string Reason { get; init; }
    public string Domain { get; init; }
    public int CountRejected { get; init; }
    public int RejectionCategoryId { get; init; }
    public string RejectionType { get; init; }
}