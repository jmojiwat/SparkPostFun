using System.Net;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record CreateSubaccountResponseWrapper
{
    public CreateSubaccountResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<SubaccountErrorResponseError> Errors { get; init; } = new List<SubaccountErrorResponseError>();
}