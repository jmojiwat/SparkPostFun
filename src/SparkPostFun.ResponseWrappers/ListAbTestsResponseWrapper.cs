using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListAbTestsResponseWrapper
{
    public IList<ListAbTestResponseResult> Results { get; init; } = new List<ListAbTestResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}