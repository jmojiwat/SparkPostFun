namespace SparkPostFun.Analytics;

public record MailboxProvidersMetricsResponseResult
{
    public IList<string> MailboxProviders { get; init; } = new List<string>();
}