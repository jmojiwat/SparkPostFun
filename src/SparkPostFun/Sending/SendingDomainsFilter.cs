namespace SparkPostFun.Sending;

public record SendingDomainsFilter
{
    public bool? OwnershipVerified { get; init; }
    public DkimStatus? DkimStatus { get; init; } 
    public CnameStatus? CnameStatus { get; init; } 
    public MxStatus? MxStatus { get; init; } 
    public AbuseAtStatus? AbuseAtStatus { get; init; } 
    public PostmasterAtStatus? PostmasterAtStatus { get; init; }
    public ComplianceStatus? ComplianceStatus { get; init; } 
    public bool? IsDefaultBounceDomain { get; init; }
}