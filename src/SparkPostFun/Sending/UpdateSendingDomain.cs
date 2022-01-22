namespace SparkPostFun.Sending;

public record UpdateSendingDomain
{
    public string TrakingDomain { get; init; }
    public UpdateDkim Dkim { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
    public bool? IsDefaultBounceDomain { get; init; }
}