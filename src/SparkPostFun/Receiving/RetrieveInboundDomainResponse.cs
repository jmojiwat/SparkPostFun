namespace SparkPostFun.Receiving
{
    public record RetrieveInboundDomainResponse
    {
        public RetrieveInboundDomainResponseResult Results { get; init; } = new();
    }
}