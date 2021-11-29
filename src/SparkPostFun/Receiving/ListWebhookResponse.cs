namespace SparkPostFun.Receiving
{
    public record ListWebhookResponse
    {
        public IList<RelayWebhook> Results { get; init; }
    }
}