namespace SparkPostFun.Sending;

public record CreateTemplateResponse
{
    public CreateTemplateResponseResult Results { get; init; } = new();
}