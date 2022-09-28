using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record EngagementDetailsResponse
    {
        public IList<EngagementDetailsResponseResult> Results { get; init; } = new List<EngagementDetailsResponseResult>();
    }
}