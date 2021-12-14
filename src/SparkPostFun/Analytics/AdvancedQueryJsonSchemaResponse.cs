namespace SparkPostFun.Analytics;

public record AdvancedQueryJsonSchemaResponse
{
    public AdvancedQueryJsonSchemaResponseResult Results { get; init; } = new();

}