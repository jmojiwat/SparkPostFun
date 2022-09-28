namespace SparkPostFun.Sending
{
    public record UpdateSnippet
    {
        public string Name { get; init; }
        public SnippetContent Content { get; init; } = new();
        public bool SharedWithSubaccounts { get; init; } = false;
    }
}