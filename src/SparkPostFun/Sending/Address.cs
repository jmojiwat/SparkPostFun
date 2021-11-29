namespace SparkPostFun.Sending
{
    public record Address
    {
        public string Email { get; init; }
        public string Name { get; init; }
        public string HeaderTo { get; internal init; }
    }
}