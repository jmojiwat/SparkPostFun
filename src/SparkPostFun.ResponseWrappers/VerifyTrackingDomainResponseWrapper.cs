using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record VerifyTrackingDomainResponseWrapper
{
    public VerifyTrackingDomainResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; }  = new List<Error>();
}