using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record SearchSuppressionsResponse
    {
        public IList<SearchSuppressionsResponseResult> Results { get; init; }
        public IList<string> Links { get; init; }
        public int TotalCount { get; init; }
    }
}