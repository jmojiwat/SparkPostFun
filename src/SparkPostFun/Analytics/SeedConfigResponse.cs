namespace SparkPostFun.Analytics;

public record SeedConfigResponse
{
    public GetSeedConfigResponseResult Results { get; init; } = new();
}