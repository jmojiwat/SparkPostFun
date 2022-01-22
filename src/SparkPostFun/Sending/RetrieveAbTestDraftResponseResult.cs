namespace SparkPostFun.Sending;

public record RetrieveAbTestDraftResponseResult
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
    public DateTimeOffset StartTime { get; init; }
    public DateTimeOffset EndTime { get; init; }
    public int TotalSampleSize { get; init; }
    public float ConfidenceLevel { get; init; }
    public int EngagementTimeout { get; init; }
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset UpdatedAt { get; init; }
}