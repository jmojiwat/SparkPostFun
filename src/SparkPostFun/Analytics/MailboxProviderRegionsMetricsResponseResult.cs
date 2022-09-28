using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record MailboxProviderRegionsMetricsResponseResult
    {
        public IList<string> MailboxProviderRegions { get; init; } = new List<string>();
    }
}