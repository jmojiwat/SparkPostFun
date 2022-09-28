namespace SparkPostFun.Analytics
{
    public record WebhookErrorResponseHeaders
    {
        public string Connection { get; set; }
        public string ContentLength { get; set; }
        public string ContentType { get; set; }
    }
}