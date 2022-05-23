using System.Net;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record AddDataPrivacyResponseWrapper
{
    public AddDataPrivacyResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<DataPrivacyError> Errors { get; init; } = new List<DataPrivacyError>();
}