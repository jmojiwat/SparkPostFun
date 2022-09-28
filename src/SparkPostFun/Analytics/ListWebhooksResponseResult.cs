using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record ListWebhooksResponseResult
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Target { get; init; }
        public IList<string> Events { get; init; } = new List<string>();
        [JsonPropertyName("auth_type")]
        public AuthenticationType AuthorizationType { get; init; }
        [JsonPropertyName("auth_request_details")]
        public AuthorizationRequestDetails AuthorizationRequestDetails { get; init; }
        [JsonPropertyName("auth_credentials")]
        public AuthorizationCredentials AuthorizationCredentials { get; init; }
        [JsonPropertyName("auth_token")]
        public string AuthorizationToken { get; init; }
        public DateTime LastSuccessful { get; init; }
        public DateTime LastFailure { get; init; }
        public object CustomHeaders { get; init; } = new();
        public bool Active { get; set; }
        public IList<WebhookLink> Links { get; set; } = new List<WebhookLink>();
    }
}