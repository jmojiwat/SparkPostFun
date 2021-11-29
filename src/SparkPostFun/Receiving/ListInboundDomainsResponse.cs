namespace SparkPostFun.Receiving
{
    public record ListInboundDomainsResponse
    {
        public IList<ListInboundDomainsResponseResult> Results { get; init; }
    }
}