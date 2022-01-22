using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record SearchMessageEventsResponseResult
{
    public string Type { get; init; }
    public string CampaignId { get; init; }
    public string CustomerId { get; init; }
    [JsonPropertyName("delv_method")]
    public string DeliveryMethod { get; init; }
    public string EventId { get; init; }
    public string FriendlyFrom { get; init; }
    public GeoIp GeoIp { get; init; }
    public DateTime InjectionTime { get; init; }
    public string IpAddress { get; init; }
    public string IpPool { get; init; }
    public string MessageId { get; init; }
    [JsonPropertyName("msg_from")]
    public string MessageFrom { get; init; }
    [JsonPropertyName("msg_size")]
    public string MessageSize { get; init; }
    [JsonPropertyName("num_retries")]
    public string NumberOfRetries { get; init; }
    public string QueueTime { get; init; }
    [JsonPropertyName("rcpt_meta")]
    public ReceiptMeta ReceiptMeta { get; init; }
    [JsonPropertyName("rcpt_tags")]
    public IList<string> ReceiptTags { get; init; }
    [JsonPropertyName("rcpt_to")]
    public string ReceiptTo { get; init; }
    [JsonPropertyName("raw_rcpt_to")]
    public string RawReceiptTo { get; init; }
    [JsonPropertyName("rcpt_type")]
    public string ReceiptType { get; init; }
    public string RecipientDomain { get; init; }
    public string RoutingDomain { get; init; }
    public string SendingDomain { get; init; }
    public string SendingIp { get; init; }
    public string SubaccountId { get; init; }
    public string Subject { get; init; }
    public string TargetLinkName { get; init; }
    public string TargetLinkUrl { get; init; }
    public string TemplateId { get; init; }
    public string TemplateVersion { get; init; }
    public DateTime Timestamp { get; init; }
    public string TransmissionId { get; init; }
    public string UserAgent { get; init; }
    public string MailboxProvider { get; init; }
    public string MailboxProviderRegion { get; init; }
}