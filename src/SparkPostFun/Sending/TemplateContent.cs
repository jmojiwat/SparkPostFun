using System.Collections.Specialized;

namespace SparkPostFun.Sending
{
    public record TemplateContent
    {
        public string Html { get; init; }
        public string Text { get; init; }
        public string AmpHtml { get; init; }
        public string Subject { get; init; }
        public SenderAddress From { get; init; }
        public string ReplyTo { get; init; }
        public NameValueCollection Headers { get; init; } = new();
    }
}
