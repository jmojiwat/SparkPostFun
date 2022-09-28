namespace SparkPostFun.Analytics
{
    public record CampaignsMetricsResponse
    {
        public CampaignsMetricsResponseResult Results { get; init; } = new();
    }
}