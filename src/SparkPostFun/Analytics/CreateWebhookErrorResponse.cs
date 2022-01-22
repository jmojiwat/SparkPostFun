namespace SparkPostFun.Analytics;

public record CreateWebhookErrorResponse : BaseErrorResponse
{
    public IList<CreateWebhookError> Errors { get; init; } = new List<CreateWebhookError>();
}