namespace SparkPostFun.Sending;

public record TrackingDomain(string Domain)
{
    public int Port { get; init; }
    public bool Secure { get; init; }
    public bool Default { get; init; }
    public TrackingDomainStatus Status { get; init; }
    public int SubaccountId { get; init; }
}