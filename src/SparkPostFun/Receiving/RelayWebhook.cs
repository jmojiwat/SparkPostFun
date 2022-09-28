using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace SparkPostFun.Receiving
{
    public record RelayWebhook
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Target { get; init; }
        public AuthenticationType? AuthenticationType { get; init; }
        public AuthenticationRequestDetails AuthenticationRequestDetails { get; init; }
        [JsonPropertyName("auth_token")]
        public string AuthenticationToken { get; init; }
        public RelayWebhookMatch Match { get; init; }
        public IDictionary<string, object> CustomHeaders { get; init; }
    }
}