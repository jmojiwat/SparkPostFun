using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record RetrieveRecipientListResponseWrapper
{
    public RetrieveRecipientListResponseResult Results { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}