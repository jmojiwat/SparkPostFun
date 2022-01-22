namespace SparkPostFun.Sending;

public record RetrieveTrackingDomainResponse
{
    public RetrieveTrackingDomainResponseResult Results { get; init; } = new();
}