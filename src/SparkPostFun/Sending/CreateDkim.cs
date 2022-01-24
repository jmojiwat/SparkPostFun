namespace SparkPostFun.Sending;

public record CreateDkim(string Private, string Public, string Selector)
{
    public string SigningDomain { get; init; }
    public string Headers { get; init; }
}