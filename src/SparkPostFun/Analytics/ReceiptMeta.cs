using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record ReceiptMeta
    {
        public string customKey { get; init; }
        public IList<string> AnotherKey { get; init; } = new List<string>();
    }
}