using System.Collections.Specialized;

namespace SparkPostFun.Analytics;

public record WebhookResponse
{
    public int Status { get; init; }
    public NameValueCollection Headers { get; init; }
}