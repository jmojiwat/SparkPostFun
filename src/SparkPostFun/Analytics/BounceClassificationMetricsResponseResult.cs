namespace SparkPostFun.Analytics
{
    public record BounceClassificationMetricsResponseResult
    {
        public string BounceClassName { get; init; }
        public string BounceClassDescription { get; init; }
        public string BounceCategoryName { get; init; }
        public int CountBounce { get; init; }
        public int CountInbandBounce { get; init; }
        public int CountOutofbandBounce { get; init; }
        public int ClassificationId { get; init; }
    }
}