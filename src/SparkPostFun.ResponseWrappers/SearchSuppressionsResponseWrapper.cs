using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record SearchSuppressionsResponseWrapper
{
    public IList<SearchSuppressionsResponseResult> Results { get; init; }
    public IList<string> Links { get; init; }
    public int TotalCount { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}