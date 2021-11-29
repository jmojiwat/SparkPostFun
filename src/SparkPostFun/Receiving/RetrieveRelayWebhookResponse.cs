namespace SparkPostFun.Receiving
{
    public record RetrieveRelayWebhookResponse
    {
        public RetrieveRelayWebhookResponseResult Results { get; init; } = new();
    }
}