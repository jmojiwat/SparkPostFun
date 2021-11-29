namespace SparkPostFun.Sending
{
    public record UpdateIpPool
    {
        public string Name { get; init; }
        public string SigningDomain { get; init; }
        public string FblSigningDomain { get; init; }
        public string AutoWarmupOverflowPool { get; init; }
    }
}