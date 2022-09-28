using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListTrackingDomainsResponse
    {
        public IList<ListTrackingDomainsResponseResult> Results { get; init; } = new List<ListTrackingDomainsResponseResult>();
    }
}