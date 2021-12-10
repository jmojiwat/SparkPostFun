namespace SparkPostFun.Accounts
{
    public record SubaccountRetrieveResponse
    {
        public uint Id { get; init; }
        public string Name { get; init; }
        public SubaccountStatus Status { get; init; }
        public string ComplianceStatus { get; init; }
        public string IpPool { get; init; }
        public SubaccountOptions Options { get; init; }
    }
}