namespace SparkPostFun.Sending
{
    public record RetrieveSuppressionSummaryResponseResult
    {
        public int Compliance { get; init; }
        public int ManuallyAdded { get; init; }
        public int UnsubscribeLink { get; init; }
        public int BounceRule { get; init; }
        public int ListUnsubscribe { get; init; }
        public int SpamComplaint { get; init; }
        public int Total { get; init; }
    }
}