namespace SparkPostFun.Analytics;

public record ListActiveCampaignsResponse
{
    public IList<CampaignResponseResult> Results { get; init; } = new List<CampaignResponseResult>();
}