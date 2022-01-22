namespace SparkPostFun.Sending;

public record ListAbTestsResponse
{
    public IList<ListAbTestResponseResult> Results { get; init; } = new List<ListAbTestResponseResult>();
}