using System.Net;
using SparkPostFun.Sending;

namespace SparkPostFun.ResponseWrappers;

public record CreateTemplateResponseWrapper
{
    public CreateTemplateResponseResult Results { get; init; } = new();
    public HttpStatusCode StatusCode { get; init; }
    public IList<TemplateError> Errors { get; init; } = new List<TemplateError>();
}