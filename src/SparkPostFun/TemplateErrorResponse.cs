using SparkPostFun.Sending;

namespace SparkPostFun;

public record TemplateErrorResponse : BaseErrorResponse
{
    public IList<TemplateError> Errors { get; init; } = new List<TemplateError>();
}