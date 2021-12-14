namespace SparkPostFun.Analytics;

public record CheckCampainStatusResponse
{
    public CampaignResponseResult Results { get; init; } = new();
}