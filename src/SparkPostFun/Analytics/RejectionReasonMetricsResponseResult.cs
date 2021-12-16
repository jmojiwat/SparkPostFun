namespace SparkPostFun.Analytics;

public record RejectionReasonMetricsResponseResult
{
    public string Reason { get; init; }
    public int CountRejected { get; init; }
    public int RejectionCategoryId { get; init; }
    public string RejectionType { get; init; }
}