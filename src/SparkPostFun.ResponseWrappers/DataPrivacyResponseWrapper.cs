using System.Net;
using SparkPostFun.Accounts;

namespace SparkPostFun.ResponseWrappers;

public record DataPrivacyResponseWrapper
{
    public AddDataPrivacyResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<DataPrivacyError> Errors { get; init; } = new List<DataPrivacyError>();
}