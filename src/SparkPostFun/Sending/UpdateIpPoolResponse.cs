namespace SparkPostFun.Sending;

public record UpdateIpPoolResponse
{
    public UpdateIpPoolResponseResult Results { get; init; } = new();
}