using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record RetrieveWebhookResponseResult
{
    public string Name { get; init; }
    public string Target { get; init; }
    public IList<string> Events { get; init; }
    [JsonPropertyName("auth_type")]
    public AuthenticationType AuthorizationType { get; init; }
    [JsonPropertyName("auth_request_details")]
    public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
    [JsonPropertyName("auth_credentials")]
    public object AuthorizationCredentials { get; init; }
    [JsonPropertyName("auth_token")]
    public string AuthorizationToken { get; init; }
    public object CustomHeaders { get; init; }
    public bool Active { get; init; }
    public IList<WebhookLink> Links { get; init; }
}