namespace SparkPostFun.Sending;

public record RetrieveSendingIpResponse
{
    public RetrieveSendingIpResponseResult Results { get; init; } = new();
}