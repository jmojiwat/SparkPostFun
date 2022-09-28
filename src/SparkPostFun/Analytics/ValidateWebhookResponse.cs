namespace SparkPostFun.Analytics
{
    public record ValidateWebhookResponse
    {
        public ValidateWebhookResponseResult Results { get; init; } = new();
    }
}