using System.Text.Json.Serialization;

namespace SparkPostFun.Receiving
{
    public record RetrieveRelayWebhookResponseResult
    {
        public string Name { get; init; }
        public string Target { get; init; }
        [JsonPropertyName("auth_token")]
        public string AuthenticationToken { get; init; }
        [JsonPropertyName("auth_type")]
        public string AuthenticationType { get; init; }
        [JsonPropertyName("auth_request_details")]
        public AuthenticationRequestDetails AuthenticationRequestDetails { get; init; }
        public IDictionary<string, string> CustomHeaders { get; init; }
        public RelayWebhookMatch Match { get; init; }
    }
}