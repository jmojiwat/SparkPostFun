namespace SparkPostFun.Analytics;

public record EventsDocumentationResponse
{
    public object Results { get; init; } = new();
}