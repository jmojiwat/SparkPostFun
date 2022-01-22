namespace SparkPostFun.Sending;

public record VerifySendingDomainResponseResult
{
    public bool OwnershipVerified { get; init; }
    public Dns Dns { get; init; }
}