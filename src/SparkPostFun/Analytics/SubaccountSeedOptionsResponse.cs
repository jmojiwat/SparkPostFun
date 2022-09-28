namespace SparkPostFun.Analytics
{
    public record SubaccountSeedOptionsResponse
    {
        public SubaccountSeedOptionsResponseResult Results { get; init; } = new();
    }
}