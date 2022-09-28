using System.Collections.Generic;

namespace SparkPostFun.Receiving
{
    public record ListRelayWebhooksResponse
    {
        public IList<ListRelayWebhooksResponseResult> Results { get; init; } = new List<ListRelayWebhooksResponseResult>();
    }
}