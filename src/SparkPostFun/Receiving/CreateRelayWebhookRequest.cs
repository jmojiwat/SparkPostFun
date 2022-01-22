using System.Text.Json.Serialization;
using SparkPostFun.Analytics;

namespace SparkPostFun.Receiving;

public record CreateRelayWebhookRequest
{
    public string Name { get; init; }
    public string Target { get; init; }
    [JsonPropertyName("auth_type")]
    public AuthenticationType? AuthenticationType { get; init; }
    [JsonPropertyName("auth_request_details")]
    public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
    [JsonPropertyName("auth_token")]
    public string AuthenticationToken { get; init; }
    // todo: figure this out
    public RelayWebhookMatch1 Match { get; init; }
    public object CustomHeaders { get; init; }
}