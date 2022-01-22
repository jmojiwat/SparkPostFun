namespace SparkPostFun.Sending;

public record VerifyTrackingDomainResponse
{
    public VerifyTrackingDomainResponseResult Results { get; init; } = new();
}