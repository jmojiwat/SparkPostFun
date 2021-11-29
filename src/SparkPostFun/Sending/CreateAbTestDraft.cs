namespace SparkPostFun.Sending
{
    public record CreateAbTestDraft
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public AbTestingTemplate DefaultTemplate { get; init; }
    }
}