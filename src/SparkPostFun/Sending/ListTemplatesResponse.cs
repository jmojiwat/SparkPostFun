using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record ListTemplatesResponse
    {
        public IList<ListTemplatesResponseResult> Results { get; init; } = new List<ListTemplatesResponseResult>();
    }
}