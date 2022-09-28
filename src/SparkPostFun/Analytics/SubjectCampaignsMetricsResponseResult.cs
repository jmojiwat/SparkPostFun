using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record SubjectCampaignsMetricsResponseResult
    {
        public IList<string> SubjectCampaigns { get; init; } = new List<string>();
    }
}