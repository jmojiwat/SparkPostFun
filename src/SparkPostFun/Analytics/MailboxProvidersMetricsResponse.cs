namespace SparkPostFun.Analytics;

public record MailboxProvidersMetricsResponse
{
    public MailboxProvidersMetricsResponseResult Results { get; init; } = new();
}