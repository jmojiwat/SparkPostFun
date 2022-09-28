namespace SparkPostFun.Sending
{
    public record UpdateDkim(string Private, string Public, string Selector)
    {
        public string SigningDomain { get; init; }
        public string Headers { get; init; }
    }
}