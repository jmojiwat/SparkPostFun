namespace SparkPostFun.Sending
{
    public record ListIpPoolsResponse
    {
        public IList<ListIpPoolsResponseResult> Results { get; init; } = new List<ListIpPoolsResponseResult>();
    }
}