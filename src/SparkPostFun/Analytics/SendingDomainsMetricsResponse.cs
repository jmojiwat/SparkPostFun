namespace SparkPostFun.Analytics;

public record SendingDomainsMetricsResponse
{
    public SendingDomainsMetricsResponseResult Results { get; init; } = new();
}