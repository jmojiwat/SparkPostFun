namespace SparkPostFun.Sending;

public record RetrieveSnippetResponse
{
    public RetrieveSnippetResponseResult Results { get; init; } = new();
}