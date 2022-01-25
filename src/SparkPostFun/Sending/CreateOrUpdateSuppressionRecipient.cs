namespace SparkPostFun.Sending;

public record CreateOrUpdateSuppressionRecipient(string Recipient, SuppressionType Type)
{
    public string Description { get; init; }
}