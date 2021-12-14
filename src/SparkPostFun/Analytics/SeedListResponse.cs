namespace SparkPostFun.Analytics;

public record SeedListResponse
{
    public IList<string> Results { get; init; } = new List<string>();
}