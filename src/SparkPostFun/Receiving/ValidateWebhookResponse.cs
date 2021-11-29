namespace SparkPostFun.Receiving
{
    public record ValidateWebhookResponse
    {
        public string Message { get; init; }
        public string Body { get; init; }
    }
}