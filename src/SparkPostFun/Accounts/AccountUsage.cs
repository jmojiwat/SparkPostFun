using System;

namespace SparkPostFun.Accounts
{
    public record AccountUsage
    {
        public DateTime? Timestamp { get; init; }
        public AccountUsagePeriod Day { get; init; }
        public AccountUsagePeriod Month { get; init; }
        public AccountUsageSandbox Sandbox { get; init; }
    }
}