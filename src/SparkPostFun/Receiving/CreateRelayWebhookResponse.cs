namespace SparkPostFun.Receiving
{
    public record CreateRelayWebhookResponse
    {
        public CreateRelayWebhookResponseResult Results { get; init; } = new();
    }
}