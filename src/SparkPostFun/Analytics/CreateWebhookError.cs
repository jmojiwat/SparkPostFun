namespace SparkPostFun.Analytics
{
    public record CreateWebhookError
    {
        public string Code { get; init; }
        public string Message { get; init; }
        public WebhookErrorResponse Response { get; init; }
    }
}