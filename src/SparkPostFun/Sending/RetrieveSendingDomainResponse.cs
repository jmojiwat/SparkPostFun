namespace SparkPostFun.Sending
{
    public record RetrieveSendingDomainResponse
    {
        public RetrieveSendingDomainResponseResult Results { get; init; } = new();
    }
}