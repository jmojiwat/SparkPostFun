namespace SparkPostFun.Sending;

public record UpdateTrackingDomainResponse
{
    public UpdateTrackingDomainResponseResult Results { get; init; } = new();
}