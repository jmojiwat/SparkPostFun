namespace SparkPostFun.Sending
{
    public record ListSendingIpsResponse
    {
        public IList<ListSendingIpsResponseResult> Results { get; init; } = new List<ListSendingIpsResponseResult>();
    }
}