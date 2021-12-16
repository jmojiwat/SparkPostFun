namespace SparkPostFun.Analytics;

public record TimeSeriesMetricsResponse
{
    public IList<TimeSeriesMetricsResponseResult> Results { get; init; } = new List<TimeSeriesMetricsResponseResult>();
}