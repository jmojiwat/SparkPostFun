namespace SparkPostFun.Sending
{
    public record ScheduleAbTestDraftResponse
    {
        public ScheduleAbTestDraftResponseResult Results { get; init; } = new();
    }
}