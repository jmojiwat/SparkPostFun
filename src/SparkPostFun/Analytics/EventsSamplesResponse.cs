namespace SparkPostFun.Analytics
{
    public record EventsSamplesResponse
    {
        public object Results { get; init; } = new();
    }
}