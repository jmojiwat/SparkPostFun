namespace SparkPostFun.Analytics;

public record MetricsFilter
{
    public string? Match { get; init; }
    public int? Limit { get; init; }
    public DateTime? From { get; init; }
    public DateTime? To { get; init; }
    public string Timezone { get; init; } = "UTC";
}