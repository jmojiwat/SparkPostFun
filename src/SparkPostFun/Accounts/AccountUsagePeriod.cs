namespace SparkPostFun.Accounts
{
    public record AccountUsagePeriod
    {
        public int? Used { get; init; }
        public int? Limit { get; init; }
        public DateTime? Start { get; init; }
        public DateTime? End { get; init; }
    }
}