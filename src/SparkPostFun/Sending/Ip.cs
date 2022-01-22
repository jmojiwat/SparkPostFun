namespace SparkPostFun.Sending;

public record Ip
{
    public string ExternalIp { get; init; }
    public string Hostname { get; init; }
    public bool? AutoWarmupEnabled { get; init; }
    public int? AutoWarmupStage { get; init; }
}