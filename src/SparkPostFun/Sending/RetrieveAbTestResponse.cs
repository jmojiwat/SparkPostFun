namespace SparkPostFun.Sending;

public record RetrieveAbTestResponse
{
    public RetrieveAbTestResponseResult Results { get; init; } = new();
}