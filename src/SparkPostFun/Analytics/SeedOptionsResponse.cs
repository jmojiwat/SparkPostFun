namespace SparkPostFun.Analytics;

public record SeedOptionsResponse
{
    public SeedOptionsResponseResult Results { get; init; } = new();
}