namespace SparkPostFun.Analytics;

public record DeliveriesByAttemptResponseResult
{
    public string Attempt { get; init; }
    public int CountDelivered { get; init; }
}