namespace SparkPostFun.Sending
{
    public record CreateOrUpdateSuppression(SuppressionType Type)
    {
        public string Description { get; init; }
    }
}