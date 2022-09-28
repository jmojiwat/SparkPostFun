using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record UpdateTemplateContent(SenderAddress From, string Subject)
    {
        public string Html { get; init; }
        public string Text { get; init; }
        public string AmpHtml { get; init; }
        public string ReplyTo { get; init; }
        public IDictionary<string, string> Headers { get; init; }
    }
}