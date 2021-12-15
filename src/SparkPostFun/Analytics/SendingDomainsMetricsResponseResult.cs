namespace SparkPostFun.Analytics;

public record SendingDomainsMetricsResponseResult
{
    public IList<string> SendingDomains { get; init; } = new List<string>();
}