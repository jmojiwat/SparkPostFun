using System.Collections.Specialized;

namespace SparkPostFun.Receiving
{
    public record RelayWebhookPayloadContent
    {
        public string Html { get; init; }
        public string Text { get; init; }
        public string Subject { get; init; }
        public IList<string> To { get; init; }
        public IList<string> Cc { get; init; }
        public IDictionary<string, object> Headers { get; init; }
        public string EmailRfc822 { get; init; }
        public bool EmailRfc822IsBase64 { get; init; }
    }
}