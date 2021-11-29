namespace SparkPostFun.Sending
{
    public record CreateSendingDomainResponse
    {
        public CreateSendingDomainResponseResult Results { get; init; } = new();
    }
}