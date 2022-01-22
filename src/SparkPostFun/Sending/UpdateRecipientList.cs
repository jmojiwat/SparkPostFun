using System.Collections.Specialized;

namespace SparkPostFun.Sending;

public record UpdateRecipientList
{
    public string Name { get; init; }
    public string Description { get; init; }
    public NameValueCollection Attributes { get; init; } = new();
    public IList<Recipient> Recipients { get; init; }
}