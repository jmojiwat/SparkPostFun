using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record UpdateWebhookRequest
{
    public string Name { get; init; }
    public string Target { get; init; }
    public IList<string> Events { get; init; }
    public bool Active { get; init; }
    public object CustomHeaders { get; init; }
    [JsonPropertyName("auth_type")]
    public AuthenticationType AuthorizationType { get; init; }
    [JsonPropertyName("auth_request_details")]
    public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
    [JsonPropertyName("auth_credentials")]
    public AuthorizationCredentials AuthorizationCredentials { get; init; }
}