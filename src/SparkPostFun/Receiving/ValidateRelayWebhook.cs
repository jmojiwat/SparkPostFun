using System.Text.Json.Serialization;

namespace SparkPostFun.Receiving;

public record ValidateRelayWebhook
{
    public RelayWebhookPayloadContent Content { get; init; }
    public string FriendlyFrom { get; init; }
    [JsonPropertyName("msg_from")]
    public string MessageFrom { get; init; }
    [JsonPropertyName("rcpt_to")]
    public string ReceiptTo { get; init; }
    public string WebhookId { get; init; }
    public static string Protocol => "smtp";
    public string CustomerId { get; init; }

}