namespace SparkPostFun.Analytics
{
    public record DomainsMetricsResponse
    {
        public SubjectCampaignsMetricsResponseResult Results { get; init; } = new();
    }
}