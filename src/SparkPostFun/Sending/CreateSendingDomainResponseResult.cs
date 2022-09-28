namespace SparkPostFun.Sending
{
    public record CreateSendingDomainResponseResult
    {
        public string Message { get; init; }
        public string Domain { get; init; }
        public Dkim Dkim { get; init; }
    }
}