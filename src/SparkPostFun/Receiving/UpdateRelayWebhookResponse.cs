namespace SparkPostFun.Receiving
{
    public record UpdateRelayWebhookResponse
    {
        public UpdateRelayWebhookResponseResult Results { get; init; } = new();
    }
}