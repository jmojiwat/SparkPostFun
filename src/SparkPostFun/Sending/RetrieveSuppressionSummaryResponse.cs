namespace SparkPostFun.Sending
{
    public record RetrieveSuppressionSummaryResponse
    {
        public RetrieveSuppressionSummaryResponseResult Results { get; init; } = new();
    }
}