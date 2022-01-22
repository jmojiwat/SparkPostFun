namespace SparkPostFun.Analytics;

public record UpdateWebhookResponse
{
    public UpdateWebhookResponseResult Results { get; init; } = new();
}