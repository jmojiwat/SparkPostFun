using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record MetricsSummaryResponse
    {
        public IList<MetricsSummaryResponseResult> Results { get; init; } = new List<MetricsSummaryResponseResult>();
        public IList<DiscoverabilityLink> Links { get; init; } = new List<DiscoverabilityLink>();
    }
}