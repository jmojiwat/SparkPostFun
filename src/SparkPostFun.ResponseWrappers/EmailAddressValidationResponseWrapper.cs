using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record EmailAddressValidationResponseWrapper
{
    public EmailAddressValidationResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; set; } = new List<Error>();
}