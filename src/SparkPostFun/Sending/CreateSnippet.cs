namespace SparkPostFun.Sending;

public record CreateSnippet(string Id, SnippetContent Content)
{
    public string Name { get; init; }
    public bool SharedWithSubaccounts { get; init; } = false;
}