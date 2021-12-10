using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListTrackingDomainsResponseWrapper
{
    public IList<ListTrackingDomainsResponseResult> Results { get; init; } = new List<ListTrackingDomainsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}