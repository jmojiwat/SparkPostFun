namespace SparkPostFun.Sending;

public record RecipientToError
{
    public string Message { get; init; }
    public string Description { get; init; }
    public string Code { get; init; }
}