namespace SparkPostFun.Sending;

public record TemplateContent
{
    public object From { get; init; }
    public string Subject { get; init; }
    public string Html { get; init; }
    public string Text { get; init; }
    public string AmpHtml { get; init; }
    public string ReplyTo { get; init; }
    public IDictionary<string, string> Headers { get; init; }
}
