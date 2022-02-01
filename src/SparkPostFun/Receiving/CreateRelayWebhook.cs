using System.Text.Json.Serialization;
using SparkPostFun.Analytics;

namespace SparkPostFun.Receiving;

public record CreateRelayWebhook(string Target, RelayWebhookMatch Match)
{
    public string Name { get; init; }

    [JsonPropertyName("auth_type")]
    public AuthenticationType? AuthenticationType { get; init; }
    [JsonPropertyName("auth_request_details")]
    public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
    [JsonPropertyName("auth_token")]
    public string AuthenticationToken { get; init; }
    // todo: figure this out
    public IDictionary<string, object> CustomHeaders { get; init; }
}