using System.Collections.Generic;

namespace SparkPostFun.Sending
{
    public record InlineContent
    {
        public InlineContent(SenderAddress from, string subject)
        {
            From = from;
            Subject = subject;
        }
    
        public InlineContent(string from, string subject)
        {
            From = from;
            Subject = subject;
        }

        public object From { get; init; }
        public string Subject { get; init; }
        public string Html { get; init; }
        public string Text { get; init; }
        public string AmpHtml { get; init; }
        public string ReplyTo { get; init; }
        public IDictionary<string, string> Headers { get; init; }
        public IList<Attachment> Attachments { get; init; }
        public IList<InlineImage> InlineImages { get; init; }
    }
}