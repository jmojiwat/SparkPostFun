namespace SparkPostFun.Analytics
{
    public record MailboxProviderRegionsMetricsResponse
    {
        public MailboxProviderRegionsMetricsResponseResult Results { get; init; } = new();
    }
}