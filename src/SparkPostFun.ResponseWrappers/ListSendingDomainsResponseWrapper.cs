using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListSendingDomainsResponseWrapper 
{
    public IList<ListSendingDomainsResponseResult> Results { get; init; } = new List<ListSendingDomainsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; }
}