using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics
{
    public record ValidateWebhookResponseResult
    {
        [JsonPropertyName("msg")]
        public string Message { get; init; }
        public WebhookResponse Response { get; init; }
    }
}