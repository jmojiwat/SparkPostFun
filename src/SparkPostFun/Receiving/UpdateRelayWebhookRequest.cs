using System.Text.Json.Serialization;
using SparkPostFun.Analytics;

namespace SparkPostFun.Receiving;

public record UpdateRelayWebhookRequest
{
    public string Name { get; set; }
    public string Target { get; set; }
    [JsonPropertyName("auth_token")]
    public string AuthenticationToken { get; init; }
    [JsonPropertyName("auth_type")]
    public AuthenticationType AuthorizationType { get; set; }
    [JsonPropertyName("auth_request_details")]
    public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
    public RelayWebhookMatch Match { get; init; }
    public IDictionary<string, object> CustomHeaders { get; set; }
}