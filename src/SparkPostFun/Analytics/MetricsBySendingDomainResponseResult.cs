namespace SparkPostFun.Analytics;

public record MetricsBySendingDomainResponseResult
{
    public string SendingDomain { get; init; }
    public int CountTargeted { get; init; }
    public int CountInjected { get; init; }
    public int CountRejected { get; init; }
    public int CountSent { get; init; }
}