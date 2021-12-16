namespace SparkPostFun.Analytics;

public record DelayReasonMetricsResponseResult
{
    public string Reason { get; init; }
    public int CountDelayed { get; init; }
    public int CountDelayedFirst { get; init; }
}