namespace SparkPostFun.Sending;

public record CreateTemplateContent
{
    public CreateTemplateContent(SenderAddress from, string subject)
    {
        Subject = subject;
        From = from;
    }

    public CreateTemplateContent(string @from, string subject)
    {
        Subject = subject;
        From = from;
    }

    public string Html { get; init; }
    public string Text { get; init; }
    public string AmpHtml { get; init; }
    public string Subject { get; init; }
    public object From { get; init; }
    public string ReplyTo { get; init; }
    public IDictionary<string, object> Headers { get; init; }
}