namespace SparkPostFun.Sending;

public record RetrieveSuppressionResponse
{
    public IList<RetrieveSuppressionResponseResult> Results { get; init; } = new List<RetrieveSuppressionResponseResult>();
    public IList<string> Links { get; init; } = new List<string>();
    public int TotalCount { get; init; }
}