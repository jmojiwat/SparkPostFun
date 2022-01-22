namespace SparkPostFun.Sending;

public record ScheduleAbTestDraft(DateTime StartTime)
{
    public DateTime EndTime { get; init; }
    public int EngagementTimeout { get; init; } = 24;
}