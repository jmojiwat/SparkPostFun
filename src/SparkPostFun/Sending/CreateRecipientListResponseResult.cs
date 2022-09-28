namespace SparkPostFun.Sending
{
    public record CreateRecipientListResponseResult
    {
        public int TotalRejectedRecipients { get; init; }
        public int TotalAcceptedRecipients { get; init; }
        public string Id { get; init; }
        public string Name { get; init; }
    }
}