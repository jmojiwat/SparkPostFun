using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record SendingIpsMetricsResponseResult
    {
        public IList<string> SendingIps { get; init; } = new List<string>();
    }
}