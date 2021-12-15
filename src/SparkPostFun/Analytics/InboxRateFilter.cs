namespace SparkPostFun.Analytics;

public record InboxRateFilter
{
    public DateTime? To { get; init; }
    public IndustryCategory IndustryCategory { get; init; } = IndustryCategory.All;
    public MailboxProvider MailboxProvider { get; init; } = Analytics.MailboxProvider.All;
    public string Timezone { get; init; } = "UTC";
}