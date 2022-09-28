namespace SparkPostFun.Sending
{
    public record ListSendingDomainsResponseResult
    {
        public string Domain { get; init; }
        public string TrackingDomain { get; init; }
        public SendingDomainStatus Status { get; init; }
        public bool SharedWithSubaccounts { get; init; }
        public bool IsDefaultBounceDomain { get; init; }
    }
}