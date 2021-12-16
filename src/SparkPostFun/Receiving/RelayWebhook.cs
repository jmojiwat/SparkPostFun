using System.Collections.Specialized;
using System.Text.Json.Serialization;

namespace SparkPostFun.Receiving
{
    public record RelayWebhook
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Target { get; init; }
        public AuthenticationType AuthenticationType { get; init; } = AuthenticationType.None;
        public AuthenticationRequestDetails AuthenticationRequestDetails { get; init; }
        [JsonPropertyName("auth_token")]
        public string AuthenticationToken { get; init; }
        public RelayWebhookMatch Match { get; init; }
        public NameValueCollection CustomHeaders { get; init; }
    }
}