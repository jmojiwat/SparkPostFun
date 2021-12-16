namespace SparkPostFun.Analytics;

public record MetricsBySubaccountResponse
{
    public IList<MetricsBySubaccountResponseResult> Results { get; init; } = new List<MetricsBySubaccountResponseResult>();
}