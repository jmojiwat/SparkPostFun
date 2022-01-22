namespace SparkPostFun.Sending;

public record Error
{
    public string Message { get; init; }
    public string Code { get; init; }
    public string Description { get; init; }
    public string Part { get; init; }
    public int? Line { get; init; }
}