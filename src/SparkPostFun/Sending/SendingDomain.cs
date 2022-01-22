namespace SparkPostFun.Sending;

public record SendingDomain(string Domain)
{
    public string TrackingDomain { get; init; }
    public SendingDomainStatus Status { get; init; }
    public Dkim Dkim { get; init; }
}