namespace SparkPostFun.Analytics;

public record DeliveriesByAttemptFilter
{
    public DateTime? To { get; init; }
    public string Delimiter { get; init; }
    public string QueryFilters { get; init; }
    public IList<string> Domains { get; init; } = new List<string>();
    public IList<string> Campaigns { get; init; } = new List<string>();
    public IList<string> MailboxProviders { get; init; } = new List<string>();
    public IList<string> MailboxProviderRegions { get; init; } = new List<string>();
    public IList<string> Templates { get; init; } = new List<string>();
    public IList<string> SendingIps { get; init; } = new List<string>();
    public IList<string> IpPools { get; init; } = new List<string>();
    public IList<string> SendingDomains { get; init; } = new List<string>();
    public IList<string> Bindings { get; init; } = new List<string>();
    public IList<string> BindingGroups { get; init; } = new List<string>();
    public IList<string> Subaccounts { get; init; } = new List<string>();
    public string Timezone { get; init; } = "UTC";
}