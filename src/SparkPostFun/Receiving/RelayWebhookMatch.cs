namespace SparkPostFun.Receiving
{
    public record RelayWebhookMatch
    {
        public string Protocol => "SMTP";
        public string Domain { get; init; }
    }
}