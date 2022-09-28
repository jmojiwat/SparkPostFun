using System;
using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record CreateAbTest(
        string Name, 
        AbTestingTemplate DefaultTemplate, 
        IList<AbTestingTemplate> Variants, 
        Metric Metric, 
        AudienceSelection AudienceSelection, 
        TestMode TestMode, 
        DateTimeOffset? StartTime)
    {
        public string Id { get; init; }
        public DateTimeOffset? EndTime { get; init; }
        public int? TotalSampleSize { get; init; }
        public float ConfidenceLevel { get; init; } = 0.95f;
        public int EngagementTimeout { get; init; } = 24;
    }
}