using System;

namespace SparkPostFun.Accounts
{
    public record AccountPendingCancellation
    {
        public DateTime? EffectiveDate { get; init; }
        public DateTime? CreateDate { get; init; }
        public string RequestingUser { get; init; } = null;
    }
}