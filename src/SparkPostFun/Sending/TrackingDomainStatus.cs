namespace SparkPostFun.Sending;

public record TrackingDomainStatus
{
    public bool Verified { get; init; }
    public CnameStatus CnameStatus { get; init; }
    public ComplianceStatus ComplianceStatus { get; init; }
}