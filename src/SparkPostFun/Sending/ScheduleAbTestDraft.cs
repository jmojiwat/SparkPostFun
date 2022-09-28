using System;

namespace SparkPostFun.Sending
{
    public record ScheduleAbTestDraft(DateTimeOffset StartTime)
    {
        public DateTimeOffset? EndTime { get; init; }
        public int? EngagementTimeout { get; init; } = 24;
    }
}