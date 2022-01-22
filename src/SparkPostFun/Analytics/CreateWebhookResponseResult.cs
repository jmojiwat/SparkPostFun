namespace SparkPostFun.Analytics;

public record CreateWebhookResponseResult
{
    public string Id { get; init; }
    public IList<WebhookLink> Links { get; init; }
}