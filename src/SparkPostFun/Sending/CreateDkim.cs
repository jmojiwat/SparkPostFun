namespace SparkPostFun.Sending
{
    public record CreateDkim
    {
        public string SigningDomain { get; init; }
        public string Private { get; init; }
        public string Public { get; init; }
        public string Selector { get; init; }
        public string Headers { get; init; }
    }
}