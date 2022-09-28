namespace SparkPostFun.Analytics
{
    public record SendingIpsMetricsResponse
    {
        public SendingIpsMetricsResponseResult Results { get; init; } = new();
    }
}