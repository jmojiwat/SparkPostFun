namespace SparkPostFun.Receiving
{
    public record ValidateRelayWebhookResponse
    {
        public ValidateRelayWebhookResponseResult Results { get; init; } = new();
    }
}