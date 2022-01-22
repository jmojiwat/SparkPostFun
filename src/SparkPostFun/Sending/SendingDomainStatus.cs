namespace SparkPostFun.Sending;

public record SendingDomainStatus
{
    public bool? OwnershipVerified { get; init; }
    public DkimStatus? DkimStatus { get; init; }
    public CnameStatus? CnameStatus { get; init; }
    public MxStatus? MxStatus { get; init; }
    public AbuseAtStatus? AbuseAtStatus { get; init; }
    public PostmasterAtStatus? PostmasterAtStatus { get; init; }
    public VerificationMailboxStatus? VerificationMailboxStatus { get; init; }
    public string VerificationMailbox { get; init; }
    public ComplianceStatus? ComplianceStatus { get; init; }
}