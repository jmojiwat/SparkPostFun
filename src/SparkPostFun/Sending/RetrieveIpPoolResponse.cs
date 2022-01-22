namespace SparkPostFun.Sending;

public record RetrieveIpPoolResponse
{
    public RetrieveIpPoolResponseResult Results { get; init; } = new();
}