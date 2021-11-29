namespace SparkPostFun.Sending
{
    public record RetrieveAbTestResponseResult
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Status { get; init; }
        public string WinningTemplateId { get; init; }
        public int Version { get; init; }
        public AbTestingTemplate DefaultTemplate { get; init; }
        public IList<AbTestingTemplate> Variants { get; init; }
        public string Metric { get; init; }
        public string AudienceSelection { get; init; }
        public string TestMode { get; init; }
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public int TotalSampleSize { get; init; }
        public float ConfidenceLevel { get; init; }
        public int EngagementTimeout { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}