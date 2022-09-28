using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record SeedConfig
    {
        public int Threshold { get; init; } = 10_000;
        public int Duration { get; init; } = 30;
        public int Reset { get; init; } = 24;
        public IList<string> Match { get; init; }
        public IList<string> Exclude { get; init; }
    }
}