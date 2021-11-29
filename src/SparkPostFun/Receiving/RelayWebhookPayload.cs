namespace SparkPostFun.Receiving
{
    public record RelayWebhookPayload
    {
        public RelayWebhookPayloadContent Content { get; init; }
        public string FriendlyFrom { get; init; }
        public string MessageFrom { get; init; }
        public string ReceiptTo { get; init; }
        public string WebhookId { get; init; }
        public string Protocol => "SMTP";
        public string CustomerId { get; init; }

    }
}