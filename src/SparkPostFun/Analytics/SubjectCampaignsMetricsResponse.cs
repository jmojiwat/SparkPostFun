namespace SparkPostFun.Analytics;

public record SubjectCampaignsMetricsResponse
{
    public SubjectCampaignsMetricsResponseResult Results { get; init; } = new();
}