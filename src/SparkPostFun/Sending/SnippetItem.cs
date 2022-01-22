namespace SparkPostFun.Sending;

public record SnippetItem
{
    public string Id { get; init; }
    public string Name { get; init; }
    public SnippetContent Content { get; init; }
    public bool SharedWithSubaccounts { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}