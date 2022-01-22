namespace SparkPostFun.Sending;

public record BulkCreateOrUpdateSuppressionsResponse
{
    public BulkCreateOrUpdateSuppressionsResponseResult Results { get; init; } = new();
}