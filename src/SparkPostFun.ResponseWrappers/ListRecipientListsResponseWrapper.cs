using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListRecipientListsResponseWrapper
{
    public IList<ListRecipientListsResponseResult> Results { get; init; } = new List<ListRecipientListsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}