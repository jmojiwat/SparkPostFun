namespace SparkPostFun.Analytics;

public record EngagementDetailsResponseResult
{
    public string LinkName { get; init; }
    public int CountClicked { get; init; }
    public int CountRawClicked { get; init; }
}