using System.Text.Json.Serialization;

namespace SparkPostFun.Sending
{
    public record Recipient
    {
        public Address Address { get; init; } = new();
        public string ReturnPath { get; init; }
        public IList<string> Tags { get; init; } = new List<string>();
        public IDictionary<string, object> Metadata { get; init; } = new Dictionary<string, object>();
        public IDictionary<string, object> SubstitutionData { get; init; } = new Dictionary<string, object>();

        [JsonIgnore]
        public RecipientType Type { get; init; } = RecipientType.To;
    }
}