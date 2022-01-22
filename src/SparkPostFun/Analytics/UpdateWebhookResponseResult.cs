namespace SparkPostFun.Analytics;

public record UpdateWebhookResponseResult
{
    public Guid Id { get; init; }
    public IList<WebhookLink> Links { get; init; }
}