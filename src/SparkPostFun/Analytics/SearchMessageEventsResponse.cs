namespace SparkPostFun.Analytics;

public record SearchMessageEventsResponse
{
    public IList<SearchMessageEventsResponseResult> Results { get; init; } = new List<SearchMessageEventsResponseResult>();
    public int TotalCount { get; set; }
    public Links Links { get; set; }
}