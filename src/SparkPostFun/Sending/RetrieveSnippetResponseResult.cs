namespace SparkPostFun.Sending;

public class RetrieveSnippetResponseResult
{
    public string Id { get; init; }
    public string Name { get; init; }
    public SnippetContent Content { get; init; }
    public bool SharedWithSubaccounts { get; init; }
    public int SubaccountId { get; init; }
}