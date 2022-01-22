using System.Text.Json.Serialization;
using SparkPostFun.Infrastructure;

namespace SparkPostFun.Sending;

public record ListAbTestResponseResult
{
    public string Id { get; init; }
    public string Name { get; init; }
    public AbTestingTemplate DefaultTemplate { get; init; }
    public IList<AbTestingTemplate> Variants { get; init; } = new List<AbTestingTemplate>();

    [JsonConverter(typeof(JsonPascalCaseConverter<Metric>))]
    public Metric Metric { get; init; }

    public AudienceSelection AudienceSelection { get; init; }
    public TestMode TestMode { get; init; }
    public DateTimeOffset? StartTime { get; init; }
    public DateTimeOffset? EndTime { get; init; }
    public int? TotalSampleSize { get; init; }
    public float ConfidenceLevel { get; init; } = 0.95f;
    public int EngagementTimeout { get; init; } = 24;
}