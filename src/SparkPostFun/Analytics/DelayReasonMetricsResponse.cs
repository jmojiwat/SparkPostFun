using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record DelayReasonMetricsResponse
    {
        public IList<DelayReasonMetricsResponseResult> Results { get; init; } = new List<DelayReasonMetricsResponseResult>();
    }
}