using System.Net;
using SparkPostFun.Analytics;

namespace SparkPostFun.ResponseWrappers;

public record CreateWebhookResponseWrapper
{
    public CreateWebhookResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<CreateWebhookError> Errors { get; init; } = new List<CreateWebhookError>();
}