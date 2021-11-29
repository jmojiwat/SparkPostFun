namespace SparkPostFun.Sending
{
    public record TrackingDomain
    {
        public string Domain { get; init; }
        public int Port { get; init; }
        public bool Secure { get; init; }
        public bool Default { get; init; }
        public TrackingDomainStatus Status { get; init; }
        public int SubaccountId { get; init; }
    }
}