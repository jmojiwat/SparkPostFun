using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListIpPoolsResponseWrapper
{
    public IList<ListIpPoolsResponseResult> Results { get; init; } = new List<ListIpPoolsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}