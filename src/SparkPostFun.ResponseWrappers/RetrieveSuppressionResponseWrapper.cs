using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record RetrieveSuppressionResponseWrapper
{
    public IList<RetrieveSuppressionResponseResult> Results { get; init; } = new List<RetrieveSuppressionResponseResult>();
    public IList<string> Links { get; init; } = new List<string>();
    public int TotalCount { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}