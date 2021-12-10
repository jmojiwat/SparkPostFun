using System.Net;
using SparkPostFun.Accounts;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record RetrieveSubaccountResponseWrapper
{
    public RetrieveSubaccountResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}