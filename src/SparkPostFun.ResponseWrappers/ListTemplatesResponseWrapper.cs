using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListTemplatesResponseWrapper
{
    public IList<ListTemplatesResponseResult> Results { get; init; } = new List<ListTemplatesResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}