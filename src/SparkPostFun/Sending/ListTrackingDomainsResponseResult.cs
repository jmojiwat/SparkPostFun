namespace SparkPostFun.Sending;

public record ListTrackingDomainsResponseResult
{
    public int? Port { get; init; }
    public string Domain { get; init; }
    public bool? Secure { get; init; }
    public bool? Default { get; init; }
    public TrackingDomainStatus Status { get; init; }
    public int? SubaccountId { get; init; }
}