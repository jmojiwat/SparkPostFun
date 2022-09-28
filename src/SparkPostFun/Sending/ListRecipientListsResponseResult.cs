using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListRecipientListsResponseResult
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public IDictionary<string, object> Attributes { get; init; }
        public int TotalAcceptedRecipients { get; init; }
    }
}