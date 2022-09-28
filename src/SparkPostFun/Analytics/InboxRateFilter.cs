using System;

namespace SparkPostFun.Analytics
{
    public record InboxRateFilter
    {
        public DateTime? To { get; init; }
        public IndustryCategory IndustryCategory { get; init; } = IndustryCategory.All;
        public MailboxProvider MailboxProvider { get; init; } = MailboxProvider.All;
        public string Timezone { get; init; } = "UTC";
    }
}