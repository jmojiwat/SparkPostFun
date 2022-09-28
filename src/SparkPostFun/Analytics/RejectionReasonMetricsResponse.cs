using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record RejectionReasonMetricsResponse
    {
        public IList<RejectionReasonMetricsResponseResult> Results { get; init; } = new List<RejectionReasonMetricsResponseResult>();
    }
}