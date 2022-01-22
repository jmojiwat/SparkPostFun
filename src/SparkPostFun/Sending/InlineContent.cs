namespace SparkPostFun.Sending;

public record InlineContent(SenderAddress From, string Subject)
{
    public string Html { get; init; }
    public string Text { get; init; }
    public string AmpHtml { get; init; }
    public string ReplyTo { get; init; }
    public IDictionary<string, string> Headers { get; init; } = new Dictionary<string, string>();
    public IList<Attachment> Attachments { get; init; } = new List<Attachment>();
    public IList<InlineImage> InlineImages { get; init; } = new List<InlineImage>();
}