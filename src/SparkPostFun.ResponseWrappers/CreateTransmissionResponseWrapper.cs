using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record CreateTransmissionResponseWrapper
{
    public IList<RecipientToError> RecipientToErrors { get; init; }
    public int TotalRejectedRecipients { get; init; }
    public int TotalAcceptedRecipients { get; init; }
    public string Id { get; init; }

    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();

}