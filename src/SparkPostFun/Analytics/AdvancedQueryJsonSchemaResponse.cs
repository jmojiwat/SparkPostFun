namespace SparkPostFun.Analytics;

public record AdvancedQueryJsonSchemaResponse
{
    public object Results { get; init; } = new();
}