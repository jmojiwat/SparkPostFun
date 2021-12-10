using System.Net;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record ListSubaccountsResponseWrapper
{
    public IList<ListSubaccountsResponseResult> Results { get; init; } = new List<ListSubaccountsResponseResult>();
    public HttpStatusCode StatusCode { get; init; }
    public IList<SubaccountErrorResponseError> Errors { get; init; } = new List<SubaccountErrorResponseError>();

}