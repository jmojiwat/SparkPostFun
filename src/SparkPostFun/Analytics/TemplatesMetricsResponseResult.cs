using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record TemplatesMetricsResponseResult
    {
        public IList<string> Templates { get; init; } = new List<string>();
    }
}