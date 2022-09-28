namespace SparkPostFun.Sending
{
    public record SenderAddress(string Email)
    {
        public string Name { get; init; }
    }
}