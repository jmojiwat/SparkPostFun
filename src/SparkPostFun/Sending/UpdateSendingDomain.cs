namespace SparkPostFun.Sending;

public record UpdateSendingDomain
{
    public string TrackingDomain { get; init; }
    public UpdateDkim Dkim { get; init; }
    public bool? SharedWithSubaccounts { get; init; }
    public bool? IsDefaultBounceDomain { get; init; }
}