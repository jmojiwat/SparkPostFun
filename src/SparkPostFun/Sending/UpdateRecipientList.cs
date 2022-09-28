using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record UpdateRecipientList
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public IDictionary<string, object> Attributes { get; init; }
        public IList<Recipient> Recipients { get; init; }
    }
}