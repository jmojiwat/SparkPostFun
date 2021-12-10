using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListSendingIpsResponseWrapper
{
    public IList<ListSendingIpsResponseResult> Results { get; init; } = new List<ListSendingIpsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}