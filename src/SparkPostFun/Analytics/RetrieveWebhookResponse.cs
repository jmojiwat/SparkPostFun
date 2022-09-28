namespace SparkPostFun.Analytics
{
    public record RetrieveWebhookResponse
    {
        public RetrieveWebhookResponseResult Results { get; init; } = new();
    }
}