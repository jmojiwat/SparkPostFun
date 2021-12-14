namespace SparkPostFun.Analytics;

public record GetSeedConfigResponseResult
{
    public IList<SeedConfig> Configs { get; init; } = new ArraySegment<SeedConfig>();
}