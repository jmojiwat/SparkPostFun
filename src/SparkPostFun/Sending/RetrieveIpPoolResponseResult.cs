namespace SparkPostFun.Sending
{
    public record RetrieveIpPoolResponseResult
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string SigningDomain { get; init; }
        public string FblSigningDomain { get; init; }
        public IList<RetrieveSendingIpResponse> Ips { get; init; } = new List<RetrieveSendingIpResponse>();
        public string AutoWarmupOverflowPool { get; init; }
    }
}