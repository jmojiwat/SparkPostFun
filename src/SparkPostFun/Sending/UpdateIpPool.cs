namespace SparkPostFun.Sending
{
    public record UpdateIpPool(string Name)
    {
        public string SigningDomain { get; init; }
        public string FblSigningDomain { get; init; }
        public string AutoWarmupOverflowPool { get; init; }
    }
}