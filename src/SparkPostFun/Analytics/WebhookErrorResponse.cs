namespace SparkPostFun.Analytics
{
    public record WebhookErrorResponse
    {
        public string Body { get; set; }
        public WebhookErrorResponseHeaders Headers { get; init; }
        public int Status { get; init; }
    }
}