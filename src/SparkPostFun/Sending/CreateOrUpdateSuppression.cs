namespace SparkPostFun.Sending
{
    public record CreateOrUpdateSuppression
    {
        public string Recipient { get; init; }
        public SuppressionType Type { get; init; }
        public string Description { get; init; }
    }


}