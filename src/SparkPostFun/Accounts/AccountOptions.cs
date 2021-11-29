namespace SparkPostFun.Accounts
{
    public record AccountOptions
    {
        public bool? SmtpTrackingDefault { get; init; }
        public bool? RestTrackingDefault { get; init; }
        public bool? TransactionalUnsubscribe { get; init; }
        public bool? TransactionalDefault { get; init; }
        public bool? InitialOpenPixelTracking { get; init; }
        public bool? ClickTracking { get; init; }
    }
}