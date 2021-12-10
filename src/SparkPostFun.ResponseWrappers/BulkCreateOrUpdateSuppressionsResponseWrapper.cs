using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record BulkCreateOrUpdateSuppressionsResponseWrapper
{
    public BulkCreateOrUpdateSuppressionsResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<Error> Errors { get; init; } = new List<Error>();
}