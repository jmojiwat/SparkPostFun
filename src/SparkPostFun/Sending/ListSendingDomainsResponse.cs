using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListSendingDomainsResponse
    {
        public IList<ListSendingDomainsResponseResult> Results { get; init; } = new List<ListSendingDomainsResponseResult>();
    }
}