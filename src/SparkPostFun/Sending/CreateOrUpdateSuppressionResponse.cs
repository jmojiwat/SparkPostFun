namespace SparkPostFun.Sending;

public record CreateOrUpdateSuppressionResponse
{
    public CreateOrUpdateSuppressionResponseResult Results { get; init; } = new();
}