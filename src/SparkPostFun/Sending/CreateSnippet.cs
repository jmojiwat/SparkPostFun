namespace SparkPostFun.Sending
{
    public record CreateSnippet
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public SnippetContent Content { get; init; } = new();
        public bool SharedWithSubaccounts { get; init; } = false;
    }
}