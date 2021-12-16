namespace SparkPostFun.Analytics;

public record DelayReasonMetricsByDomainResponseResult
{
    public string Reason { get; init; }
    public string Domain { get; init; }
    public int CountDelayed { get; init; }
    public int CountDelayedFirst { get; init; }
}