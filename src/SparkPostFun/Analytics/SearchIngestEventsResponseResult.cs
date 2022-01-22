namespace SparkPostFun.Analytics;

public record SearchIngestEventsResponseResult
{
    public bool Retryable { get; init; }
    public int NumberSucceeded { get; init; }
    public Guid EventId { get; init; }
    public int NumberFailed { get; init; }
    public Guid BatchId { get; init; }
    public DateTime ExpirationTimestamp { get; init; }
    public string ErrorType { get; init; }
    public string Href { get; init; }
    public string Type { get; init; }
    public int CustomerId { get; init; }
    public int SubaccountId { get; init; }
    public int NumberDuplicates { get; init; }
    public DateTime Timestamp { get; init; }

}