using System.Collections.Specialized;
using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record RecipientResponse
    {
        public Address Address { get; init; } = new(string.Empty);
        public IList<string> Tags { get; init; } = new List<string>();
        public NameValueCollection Metadata { get; init; } = new();
        public NameValueCollection SubstitutionData { get; init; } = new();
    }
}