namespace SparkPostFun.Sending;

public record RetrieveSendingDomainResponseResult
{
    public string TrackingDomain { get; init; }
    public SendingDomainStatus Status { get; init; }
    public Dkim Dkim { get; init; }
    public bool SharedWithSubaccounts { get; init; }
    public bool IsDefaultBounceDomain { get; init; }
}