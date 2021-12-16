using System.Text.Json.Serialization;

namespace SparkPostFun.Analytics;

public record TimeSeriesMetricsResponseResult
{
    public int CountAccepted { get; init; }
    public int CountAdminBounce { get; init; }
    public int CountBlockBounce { get; init; }
    public int CountBounce { get; init; }
    public int CountClicked { get; init; }
    public int CountDelayed { get; init; }
    public int CountDelayedFirst { get; init; }
    public int CountDelivered { get; init; }
    public int CountDeliveredFirst { get; init; }
    public int CountDeliveredSubsequent { get; init; }
    public int CountGenerationFailed { get; init; }
    public int CountGenerationRejection { get; init; }
    public int CountHardBounce { get; init; }
    public int CountInbandBounce { get; init; }
    public int CountInitialRendered { get; init; }
    public int CountInjected { get; init; }
    public int CountOutofbandBounce { get; init; }
    public int CountPolicyRejection { get; init; }
    public int CountRejected { get; init; }
    public int CountRendered { get; init; }
    public int CountSent { get; init; }
    public int CountSoftBounce { get; init; }
    public int CountSpamComplaint { get; init; }
    public int CountTargeted { get; init; }
    public int CountUndeterminedBounce { get; init; }
    public int CountUniqueClicked { get; init; }
    public int CountUniqueConfirmedOpened { get; init; }
    public int CountUniqueInitialRendered { get; init; }
    public int CountUniqueRendered { get; init; }
    public int CountUnsubscribe { get; init; }
    public int TotalDeliveryTimeFirst { get; init; }
    public int TotalDeliveryTimeSubsequent { get; init; }
    public int TotalMsgVolume { get; init; }
    [JsonPropertyName("ts")]
    public DateTime Timestamp { get; init; }
}