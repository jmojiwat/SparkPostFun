namespace SparkPostFun.Receiving;

public record CreateRelayWebhookErrorResponse : BaseErrorResponse
{
    public IList<CreateRelayWebhookError> Errors { get; init; } = new List<CreateRelayWebhookError>();
}