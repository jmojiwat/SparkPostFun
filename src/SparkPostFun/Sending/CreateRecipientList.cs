namespace SparkPostFun.Sending;

public record CreateRecipientList(IList<Recipient> Recipients)
{
    public string Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public IDictionary<string, object> Attributes { get; init; }
}