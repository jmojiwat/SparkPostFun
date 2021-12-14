namespace SparkPostFun.Analytics;

public record SeedOptions
{
    public int SubaccountId { get; init; }
    public bool Enabled { get; init; }
}