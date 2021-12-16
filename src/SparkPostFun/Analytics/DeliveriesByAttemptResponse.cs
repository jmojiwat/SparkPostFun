namespace SparkPostFun.Analytics;

public record DeliveriesByAttemptResponse
{
    public IList<DeliveriesByAttemptResponseResult> Results { get; init; } = new List<DeliveriesByAttemptResponseResult>();
}