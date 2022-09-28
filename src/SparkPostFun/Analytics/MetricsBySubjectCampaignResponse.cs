using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record MetricsBySubjectCampaignResponse
    {
        public IList<MetricsBySubjectCampaignResponseResult> Results { get; init; } = new List<MetricsBySubjectCampaignResponseResult>();
    }
}