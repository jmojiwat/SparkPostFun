namespace SparkPostFun.Sending
{
    public record UpdateAbTest
    {
        public string Name { get; init; }
        public AbTestingTemplate? DefaultTemplate { get; init; }
        public IList<AbTestingTemplate> Variants { get; init; } = new List<AbTestingTemplate>();
        public Metric? Metric { get; init; }
        public AudienceSelection? AudienceSelection { get; init; }
        public TestMode? TestMode { get; init; }
        public DateTime? StartTime { get; init; }
        public DateTime? EndTime { get; init; }
        public int? TotalSampleSize { get; init; }
        public float? ConfidenceLevel { get; init; }
        public int? EngagementTimeout { get; init; }
    }
}