namespace SparkPostFun.Accounts
{
    public record UpdateSubaccount
    {
        public string Name { get; init; }
        public SubaccountStatus? Status { get; init; }
        public string IpPool { get; init; }
        public SubaccountOptions Options { get; init; }
    }
}