namespace SparkPostFun.Sending;

public record RetrieveSendingIpResponseResult
{
    public string ExternalIp { get; init; }
    public string HostName { get; init; }
    public string IpPool { get; init; }
    public bool CustomerProvided { get; init; }
    public bool AutoWarmupEnabled { get; init; }
    public int AutoWarmupStage { get; init; }
}