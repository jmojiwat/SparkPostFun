namespace SparkPostFun.Sending;

public record UpdateDkim
{
    public string SigningDomain { get; init; }
    public string Private { get; init; }
    public string Public { get; init; }
    public string Selector { get; init; }
    public string Headers { get; init; }
}