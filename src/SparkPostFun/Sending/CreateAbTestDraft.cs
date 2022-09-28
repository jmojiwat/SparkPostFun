namespace SparkPostFun.Sending
{
    public record CreateAbTestDraft(string Name, AbTestingTemplate DefaultTemplate)
    {
        public string Id { get; init; }
    }
}