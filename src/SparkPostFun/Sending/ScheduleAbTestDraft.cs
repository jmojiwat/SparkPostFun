namespace SparkPostFun.Sending
{
    public record ScheduleAbTestDraft
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EngagementTimeout { get; set; } = 24;

    }
}