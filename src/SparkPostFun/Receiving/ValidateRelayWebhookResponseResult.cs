using System.Text.Json.Serialization;

namespace SparkPostFun.Receiving
{
    public record ValidateRelayWebhookResponseResult
    {
        [JsonPropertyName("msg")]
        public string Message { get; init; }
        public RelayWebhookResponse Response { get; init; }
    }
}