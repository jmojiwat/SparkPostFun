namespace SparkPostFun.Analytics;

public record MetricsByTemplateResponse
{
    public IList<MetricsByTemplateResponseResult> Results { get; init; } = new List<MetricsByTemplateResponseResult>();
}