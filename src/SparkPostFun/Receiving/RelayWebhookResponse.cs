namespace SparkPostFun.Receiving
{
    public record RelayWebhookResponse
    {
        public int? Status { get; init; }
        public IDictionary<string, string> Headers { get; init; }
        public string Body { get; init; }
    }
}