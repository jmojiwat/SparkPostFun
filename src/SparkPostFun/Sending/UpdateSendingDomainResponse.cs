namespace SparkPostFun.Sending;

public record UpdateSendingDomainResponse
{
    public UpdateSendingDomainResponseResult Results { get; init; } = new();
}