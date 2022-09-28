namespace SparkPostFun.Sending
{
    public record UpdateSendingDomainResponseResult
    {
        public string Message { get; init; }
        public string Domain { get; init; }
    }
}