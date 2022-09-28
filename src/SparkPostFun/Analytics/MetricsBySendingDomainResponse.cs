using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record MetricsBySendingDomainResponse
    {
        public IList<MetricsBySendingDomainResponseResult> Results { get; init; } = new List<MetricsBySendingDomainResponseResult>();
    }
}