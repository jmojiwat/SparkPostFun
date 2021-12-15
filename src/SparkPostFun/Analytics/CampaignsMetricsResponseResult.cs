namespace SparkPostFun.Analytics;

public record CampaignsMetricsResponseResult
{
    public IList<string> Campaigns { get; init; } = new List<string>();
}