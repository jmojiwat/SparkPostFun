namespace SparkPostFun.Analytics;

public record ListWebhooksResponse
{
    public IList<ListWebhooksResponseResult> Results = new List<ListWebhooksResponseResult>();
}