namespace SparkPostFun.Analytics;

public record MetricsByCampaignResponse
{
    public IList<MetricsByCampaignResponseResult> Results { get; init; } = new List<MetricsByCampaignResponseResult>();
}