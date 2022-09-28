namespace SparkPostFun.Receiving
{
    public record CreateRelayWebhookError
    {
        public string Param { get; init; }
        public string Message { get; init; }
        public string Value { get; init; }
    }
}