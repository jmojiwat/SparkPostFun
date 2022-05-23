using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ResponseListResultWrapper<TResult>
{
    public IList<TResult> Results { get; init; } = new List<TResult>();
    
    public HttpStatusCode StatusCode { get; init; }

    public IList<Error> Errors { get; init; } = new List<Error>();
}
