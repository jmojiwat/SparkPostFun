namespace SparkPostFun.Sending;

public record CreateTrackingDomain
{
    public string Domain { get; init; }
    public bool? Secure { get; init; }
}