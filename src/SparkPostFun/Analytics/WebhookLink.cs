namespace SparkPostFun.Analytics;

public record WebhookLink
{
    public string Href { get; init; }
    public string Rel { get; init; }
    public IList<string> Method { get; init; }
}