namespace SparkPostFun.Sending
{
    public record CreateSnippetResponse
    {
        public CreateSnippetResponseResult Results { get; init; } = new();
    }
}