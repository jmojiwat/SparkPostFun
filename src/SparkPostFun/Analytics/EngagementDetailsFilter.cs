using System;
using System.Collections.Generic;

namespace SparkPostFun.Analytics
{
    public record EngagementDetailsFilter
    {
        public DateTime? To { get; init; }
        public string Delimiter { get; init; }
        public string QueryFilters { get; init; }
        public string Timezone { get; init; } = "UTC";
        public IList<Metric> Metrics { get; init; } = new List<Metric>();
        public IList<string> Campaigns { get; init; } = new List<string>();
        public IList<string> MailboxProviders { get; init; } = new List<string>();
        public IList<string> MailboxProviderRegions { get; init; } = new List<string>();
        public IList<string> Templates { get; init; } = new List<string>();
        public IList<string> SendingDomains { get; init; } = new List<string>();
        public IList<string> Subaccounts { get; init; } = new List<string>();
        public int? Limit { get; init; }
    }
}