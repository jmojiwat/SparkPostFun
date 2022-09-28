using System;

namespace SparkPostFun.Sending
{
    public record Dkim
    {
        public string SigningDomain { get; init; }
        public string Public { get; init; }
        public string Selector { get; init; }
        public string Headers { get; init; }
        public bool? SharedWithSubaccounts { get; init; }
        public int? SubaccountId { get; init; }
        public bool? IsDefaultBounceDomain { get; init; }
        public DateTimeOffset? CreationTime { get; init; }
        public bool? Delegated { get; init; }
    }
}