namespace SparkPostFun.Accounts
{
    public record AccountUsageSandbox
    {
        public int? Used { get; init; }
        public int? Limit { get; init; }
    }
}