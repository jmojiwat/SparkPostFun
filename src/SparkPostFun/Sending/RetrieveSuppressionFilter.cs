using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record RetrieveSuppressionFilter
    {
        public IList<SuppressionType> Types { get; init; } = new List<SuppressionType>();
        public string Cursor { get; init; }
        public int? PerPage { get; init; }
        public int? Page { get; init; }
    }
}