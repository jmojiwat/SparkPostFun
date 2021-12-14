namespace SparkPostFun.Analytics;

public record Defs
{
    public Groupings Groupings { get; init; } = new();
    public Filters Filters { get; init; } = new();
    public LogicalOperators LogicalOperators { get; init; } = new();
}