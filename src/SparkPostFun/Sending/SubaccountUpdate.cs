namespace SparkPostFun.Sending
{
    public record SubaccountUpdate
    {
        public string Name { get; init; }
        public SubaccountStatus Status { get; init; }
        public string IpPool { get; init; }
    }
}