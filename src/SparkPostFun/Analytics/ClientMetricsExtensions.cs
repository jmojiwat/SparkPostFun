using System.Collections.Specialized;
using LanguageExt;

namespace SparkPostFun.Analytics;

public static class ClientMetricsExtensions
{
    public static Task<Either<ErrorResponse, AdvancedQueryJsonSchemaResponse>> AdvancedQueryJsonSchema(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/query-filters-schema";
        return @this.Get<AdvancedQueryJsonSchemaResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> DiscoverabilityLinks(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics";
        return @this.Get<DiscoverabilityLinksResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> MetricsSummary(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsSummary(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, DiscoverabilityLinksResponse>> MetricsSummary(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability?{queryString}";
        return @this.Get<DiscoverabilityLinksResponse>(requestUrl);
    }
    
    // todo: implement Metrics Aggregations methods: MetricsByRecipientDomain, MetricsBySendingIp, MetricsByIpPool...
    
    public static Task<Either<ErrorResponse, IpPoolsMetricsResponse>> IpPoolsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/ip-pools";
        return @this.Get<IpPoolsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, IpPoolsMetricsResponse>> IpPoolsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/ip-pools?{queryString}";
        return @this.Get<IpPoolsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, SendingIpsMetricsResponse>> SendingIpsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/sending-ips";
        return @this.Get<SendingIpsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SendingIpsMetricsResponse>> SendingIpsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/sending-ips?{queryString}";
        return @this.Get<SendingIpsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, MailboxProviderRegionsMetricsResponse>> MailboxProviderRegionsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/mailbox-provider-regions";
        return @this.Get<MailboxProviderRegionsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, MailboxProviderRegionsMetricsResponse>> MailboxProviderRegionsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/mailbox-provider-regions?{queryString}";
        return @this.Get<MailboxProviderRegionsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, MailboxProvidersMetricsResponse>> MailboxProvidersMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/mailbox-providers";
        return @this.Get<MailboxProvidersMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, MailboxProvidersMetricsResponse>> MailboxProvidersMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/mailbox-providers?{queryString}";
        return @this.Get<MailboxProvidersMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, CampaignsMetricsResponse>> CampaignsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/campaigns";
        return @this.Get<CampaignsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, CampaignsMetricsResponse>> CampaignsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/campaigns?{queryString}";
        return @this.Get<CampaignsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, TemplatesMetricsResponse>> TemplatesMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/templates";
        return @this.Get<TemplatesMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, TemplatesMetricsResponse>> TemplatesMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/templates?{queryString}";
        return @this.Get<TemplatesMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, DomainsMetricsResponse>> DomainsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/domains";
        return @this.Get<DomainsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, DomainsMetricsResponse>> DomainsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/domains?{queryString}";
        return @this.Get<DomainsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, SubjectCampaignsMetricsResponse>> SubjectCampaignsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/subject-campaigns";
        return @this.Get<SubjectCampaignsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SubjectCampaignsMetricsResponse>> SubjectCampaignsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/subject-campaigns?{queryString}";
        return @this.Get<SubjectCampaignsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, SendingDomainsMetricsResponse>> SendingDomainsMetrics(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/metrics/sending-domains";
        return @this.Get<SendingDomainsMetricsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SendingDomainsMetricsResponse>> SendingDomainsMetrics(this Client @this, MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/metrics/sending-domains?{queryString}";
        return @this.Get<SendingDomainsMetricsResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, InboxRateMetricsResponse>> InboxRateMetrics(this Client @this, DateTime from) => 
        InboxRateMetrics(@this, @from, new InboxRateFilter());

    public static Task<Either<ErrorResponse, InboxRateMetricsResponse>> InboxRateMetrics(this Client @this, DateTime from, InboxRateFilter filter)
    {
        var queryString = ToQueryString(from, filter);
        
        var requestUrl = $"/api/{@this.Version}/metrics/benchmarks/inbox-rate?{queryString}";
        return @this.Get<InboxRateMetricsResponse>(requestUrl);
    }
    
    private static string ToQueryString(DateTime from, InboxRateFilter filter)
    {
        var queryString = new NameValueCollection { { "from", @from.ToString("s") } };

        if(filter.To != null)
        {
            queryString.Add("to", filter.To?.ToString("s"));
        }
        queryString.Add("industry_category", filter.IndustryCategory.ToString());

        queryString.Add("mailbox_provider", filter.MailboxProvider.ToString());

        if(filter.Timezone != null)
        {
            queryString.Add("timezone", filter.Timezone);
        }
        
        return queryString.ToString();
    }
    
    private static string ToQueryString(MetricsFilter filter)
    {
        var queryString = new NameValueCollection();

        if(filter.Match != null)
        {
            queryString.Add("match", filter.Match);
        }
        if(filter.Limit != null)
        {
            queryString.Add("limit", filter.Limit.ToString());
        }
        if(filter.From != null)
        {
            queryString.Add("from", filter.From?.ToString("s"));
        }
        if(filter.To != null)
        {
            queryString.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Timezone != null)
        {
            queryString.Add("timezone", filter.Timezone);
        }
        
        return queryString.ToString();
    }
    
    private static string ToQueryString(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = new NameValueCollection
        {
            { "from", from.ToString("s")},  
            { "metrics", string.Concat(',', metrics)}  
        };

        if(filter.To != null)
        {
            queryString.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Delimiter != null)
        {
            queryString.Add("delimiter", filter.Delimiter);
        }
        if(filter.QueryFilters != null)
        {
            queryString.Add("query_filters", filter.QueryFilters);
        }
        if(filter.Domains != null)
        {
            queryString.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Campaigns != null)
        {
            queryString.Add("campaigns", string.Concat(',', filter.Campaigns));
        }
        if(filter.SubjectCampaigns != null)
        {
            queryString.Add("subject_campaigns", string.Concat(',', filter.SubjectCampaigns));
        }
        if(filter.MailboxProviders != null)
        {
            queryString.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }
        if(filter.MailboxProviderRegions != null)
        {
            queryString.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }
        if(filter.Templates != null)
        {
            queryString.Add("templates", string.Concat(',', filter.Templates));
        }
        if(filter.SendingIps != null)
        {
            queryString.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }
        if(filter.IpPools != null)
        {
            queryString.Add("ip_pools", string.Concat(',', filter.IpPools));
        }
        if(filter.SendingDomains != null)
        {
            queryString.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }
        if(filter.Subaccounts != null)
        {
            queryString.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }
        if(filter.Domains != null)
        {
            queryString.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Precision != null)
        {
            queryString.Add("precision", filter.Precision.ToString());
        }
        queryString.Add("timezone", filter.Timezone);
        
        return queryString.ToString();
    }
}

/*
public DateTime To { get; init; }
public string Delimiter { get; init; }
public string QueryFilters { get; init; }
public IList<string> Domains { get; init; } = new List<string>();
public IList<string> Campaigns { get; init; } = new List<string>();
public IList<string> SubjectCampaigns { get; init; } = new List<string>();
public IList<string> MailboxProviders { get; init; } = new List<string>();
public IList<string> MailboxProviderRegions { get; init; } = new List<string>();
public IList<string> Templates { get; init; } = new List<string>();
public IList<string> SendingIps { get; init; } = new List<string>();
public IList<string> IpPools { get; init; } = new List<string>();
public IList<string> SendingDomains { get; init; } = new List<string>();
public IList<string> Subaccounts { get; init; } = new List<string>();
public MetricsSummaryPrecision Precision { get; init; } = MetricsSummaryPrecision.OneMinute;
*/
