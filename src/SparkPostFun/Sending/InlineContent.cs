namespace SparkPostFun.Sending
{
    public record InlineContent
    {
        public SenderAddress From { get; init; }
        public string Subject { get; init; }
        public string Html { get; init; }
        public string Text { get; init; }
        public string AmpHtml { get; init; }
        public string ReplyTo { get; init; }
        public IDictionary<string, string> Headers { get; init; } = new Dictionary<string, string>();
        public IList<Attachment> Attachments { get; init; }
        public IList<InlineImage> InlineImages { get; init; }
    }
}