using System.Text.Json.Serialization;

namespace SparkPostFun.Sending;

public record Recipient(Address Address)
{
    public string ReturnPath { get; init; }
    public IList<string> Tags { get; init; }
    public IDictionary<string, object> Metadata { get; init; }
    public IDictionary<string, object> SubstitutionData { get; init; }

    [JsonIgnore] public RecipientType Type { get; init; } = RecipientType.To;
}