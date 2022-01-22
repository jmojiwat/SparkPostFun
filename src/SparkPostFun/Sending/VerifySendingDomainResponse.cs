namespace SparkPostFun.Sending;

public record VerifySendingDomainResponse
{
    public VerifySendingDomainResponseResult Results { get; init; } = new();
}