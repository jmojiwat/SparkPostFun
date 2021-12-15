namespace SparkPostFun.Analytics;

public record TemplatesMetricsResponse
{
    public TemplatesMetricsResponseResult Results { get; init; } = new();
}