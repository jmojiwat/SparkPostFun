namespace SparkPostFun.Sending;

public record UpdateSendingIp
{
    public string IpPool { get; init; }
    public bool? CustomerProvided { get; init; }
    public bool? AutoWarmupEnabled { get; init; }
    public int? AutoWarmupStage { get; init; }
}