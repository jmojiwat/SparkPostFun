namespace SparkPostFun.Sending
{
    public record ListAbTestResponse
    {
        public IList<ListAbTestResponseResult> Results { get; init; } = new List<ListAbTestResponseResult>();
    }
}