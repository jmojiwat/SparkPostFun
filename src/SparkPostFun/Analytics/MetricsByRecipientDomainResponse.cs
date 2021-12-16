namespace SparkPostFun.Analytics;

public record MetricsByRecipientDomainResponse
{
    public IList<MetricsByRecipientDomainResponseResult> Results { get; init; } = new List<MetricsByRecipientDomainResponseResult>();
}