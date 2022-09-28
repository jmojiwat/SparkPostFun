using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record SearchIngestEventsResponse
    {
        public IList<SearchIngestEventsResponseResult> Results { get; init; } = new List<SearchIngestEventsResponseResult>();
        public int TotalCount { get; set; }
        public Links Links { get; set; }
    }
}