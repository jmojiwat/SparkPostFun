namespace SparkPostFun.Sending;

public record CreateOrUpdateSuppression(string Recipient, SuppressionType Type)
{
    public string Description { get; init; }
}