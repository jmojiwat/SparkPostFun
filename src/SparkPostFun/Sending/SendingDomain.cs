namespace SparkPostFun.Sending
{
    public record SendingDomain
    {
        public string Domain { get; init; }
        public string TrackingDomain { get; init; }
        public SendingDomainStatus Status { get; init; }
        public Dkim Dkim { get; init; }
    }
}