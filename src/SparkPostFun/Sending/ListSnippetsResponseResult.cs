namespace SparkPostFun.Sending
{
    public record ListSnippetsResponseResult
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public bool SharedWithSubaccounts { get; init; } = false;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
    }
}