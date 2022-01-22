namespace SparkPostFun.Sending;

public record SnippetContent
{
    public string Html { get; init; }
    public string Text { get; init; }
    public string AmpHtml { get; init; }
}