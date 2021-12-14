namespace SparkPostFun.Analytics;

public record CampaignResponseResult
{
    public string Campaign { get; init; }
    public string SendingDomain { get; init; }
    public int Count { get; init; }
    public int Threshold { get; init; }
    public int SeedStart { get; init; }
    public int Duration { get; init; }
    public string SubaccountId { get; init; }
}
