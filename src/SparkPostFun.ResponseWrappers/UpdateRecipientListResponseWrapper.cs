using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record UpdateRecipientListResponseWrapper
{
    public UpdateRecipientListResponseResult Results { get; init; }
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}