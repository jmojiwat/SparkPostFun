namespace SparkPostFun.Sending;

public record CreateTransmissionResponseError
{
    public string Message { get; init; }
    public string Code { get; init; }
}