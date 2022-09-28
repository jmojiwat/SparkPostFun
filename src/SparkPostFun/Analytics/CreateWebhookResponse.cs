namespace SparkPostFun.Analytics
{
    public record CreateWebhookResponse
    {
        public CreateWebhookResponseResult Results { get; init; } = new();
    }
}