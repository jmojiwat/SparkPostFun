namespace SparkPostFun.Sending;

public record UpdateTrackingDomain
{
    public bool? Secure { get; init; }
    public bool? Default { get; init; }
}