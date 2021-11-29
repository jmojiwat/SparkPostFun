using System.Collections.Specialized;

namespace SparkPostFun.Receiving
{
    public record RetrieveWebhookResponse
    {
        public string Name { get; init; }
        public string Target { get; init; }
        public string AuthenticationToken { get; init; }
        public AuthenticationType AuthenticationType { get; init; }
        public AuthenticationRequestDetails AuthenticationRequestDetails { get; init; }
        public NameValueCollection CustomHeaders { get; init; }
        public RelayWebhookMatch Match { get; init; }
    }
}