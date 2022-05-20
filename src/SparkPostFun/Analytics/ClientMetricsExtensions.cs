using System.Collections.Specialized;
using LanguageExt;
using SparkPostFun.Infrastructure;

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

    // todo: complete implementation
    public static Task<Either<ErrorResponse, MetricsByRecipientDomainResponse>> MetricsByRecipientDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByRecipientDomain(@this, from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByRecipientDomainResponse>> MetricsByRecipientDomain(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/domain?{queryString}";
        return @this.Get<MetricsByRecipientDomainResponse>(requestUrl);
    }
    
    public static Task<Either<ErrorResponse, MetricsBySendingIpResponse>> MetricsBySendingIp(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsBySendingIp(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsBySendingIpResponse>> MetricsBySendingIp(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/sending-ip?{queryString}";
        return @this.Get<MetricsBySendingIpResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, MetricsByIpPoolResponse>> MetricsByIpPool(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByIpPool(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByIpPoolResponse>> MetricsByIpPool(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/ip-pool?{queryString}";
        return @this.Get<MetricsByIpPoolResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsBySendingDomainResponse>> MetricsBySendingDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsBySendingDomain(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsBySendingDomainResponse>> MetricsBySendingDomain(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/sending-domain?{queryString}";
        return @this.Get<MetricsBySendingDomainResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsBySubaccountResponse>> MetricsBySubaccount(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsBySubaccount(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsBySubaccountResponse>> MetricsBySubaccount(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/subaccount?{queryString}";
        return @this.Get<MetricsBySubaccountResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsByCampaignResponse>> MetricsByCampaign(this Client @this, DateTime from, IList<Metric> metrics, string sample) => 
        MetricsByCampaign(@this, @from, metrics, sample, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByCampaignResponse>> MetricsByCampaign(this Client @this, DateTime from, IList<Metric> metrics, string sample, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, sample, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/campaign?{queryString}";
        return @this.Get<MetricsByCampaignResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsByTemplateResponse>> MetricsByTemplate(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByTemplate(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByTemplateResponse>> MetricsByTemplate(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/template?{queryString}";
        return @this.Get<MetricsByTemplateResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsBySubjectCampaignResponse>> MetricsBySubjectCampaign(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsBySubjectCampaign(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsBySubjectCampaignResponse>> MetricsBySubjectCampaign(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/subject-campaign?{queryString}";
        return @this.Get<MetricsBySubjectCampaignResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsByWatchedDomainResponse>> MetricsByWatchedDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByWatchedDomain(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByWatchedDomainResponse>> MetricsByWatchedDomain(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/watched-domain?{queryString}";
        return @this.Get<MetricsByWatchedDomainResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsByMailboxProviderResponse>> MetricsByMailboxProvider(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByMailboxProvider(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByMailboxProviderResponse>> MetricsByMailboxProvider(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/mailbox-provider?{queryString}";
        return @this.Get<MetricsByMailboxProviderResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, MetricsByMailboxProviderRegionResponse>> MetricsByMailboxProviderRegion(this Client @this, DateTime from, IList<Metric> metrics) => 
        MetricsByMailboxProviderRegion(@this, @from, metrics, new AggregateMetricsFilter());

    public static Task<Either<ErrorResponse, MetricsByMailboxProviderRegionResponse>> MetricsByMailboxProviderRegion(this Client @this, DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/mailbox-provider-region?{queryString}";
        return @this.Get<MetricsByMailboxProviderRegionResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, TimeSeriesMetricsResponse>> TimeSeriesMetrics(this Client @this, DateTime from, IList<Metric> metrics) => 
        TimeSeriesMetrics(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, TimeSeriesMetricsResponse>> TimeSeriesMetrics(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/time-series?{queryString}";
        return @this.Get<TimeSeriesMetricsResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, BounceReasonMetricsResponse>> BounceReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics) => 
        BounceReasonMetrics(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, BounceReasonMetricsResponse>> BounceReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/bounce-reason?{queryString}";
        return @this.Get<BounceReasonMetricsResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, BounceReasonMetricsByDomainResponse>> BounceReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        BounceReasonMetricsByDomain(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, BounceReasonMetricsByDomainResponse>> BounceReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/bounce-reason/domain?{queryString}";
        return @this.Get<BounceReasonMetricsByDomainResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, BounceClassificationMetricsResponse>> BounceClasificationMetrics(this Client @this, DateTime from, IList<Metric> metrics) => 
        BounceClasificationMetrics(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, BounceClassificationMetricsResponse>> BounceClasificationMetrics(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/bounce-classification?{queryString}";
        return @this.Get<BounceClassificationMetricsResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, RejectionReasonMetricsResponse>> RejectionReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics) => 
        RejectionReasonMetrics(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, RejectionReasonMetricsResponse>> RejectionReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/rejection-reason?{queryString}";
        return @this.Get<RejectionReasonMetricsResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, RejectionReasonMetricsByDomainResponse>> RejectionReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        RejectionReasonMetricsByDomain(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, RejectionReasonMetricsByDomainResponse>> RejectionReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/rejection-reason/domain?{queryString}";
        return @this.Get<RejectionReasonMetricsByDomainResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, DelayReasonMetricsResponse>> DelayReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics) => 
        DelayReasonMetrics(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, DelayReasonMetricsResponse>> DelayReasonMetrics(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/delay-reason?{queryString}";
        return @this.Get<DelayReasonMetricsResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, DelayReasonMetricsByDomainResponse>> DelayReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics) => 
        DelayReasonMetricsByDomain(@this, @from, metrics, new MetricsSummaryFilter());

    public static Task<Either<ErrorResponse, DelayReasonMetricsByDomainResponse>> DelayReasonMetricsByDomain(this Client @this, DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/delay-reason/domain?{queryString}";
        return @this.Get<DelayReasonMetricsByDomainResponse>(requestUrl);
    }
    public static Task<Either<ErrorResponse, EngagementDetailsResponse>> EngagementDetails(this Client @this, DateTime from, IList<Metric> metrics) => 
        EngagementDetails(@this, @from, metrics, new EngagementDetailsFilter());

    public static Task<Either<ErrorResponse, EngagementDetailsResponse>> EngagementDetails(this Client @this, DateTime from, IList<Metric> metrics, EngagementDetailsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/link-name?{queryString}";
        return @this.Get<EngagementDetailsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, DeliveriesByAttemptResponse>> DeliveriesByAttempt(this Client @this, DateTime from) => 
        DeliveriesByAttempt(@this, from, new DeliveriesByAttemptFilter());

    public static Task<Either<ErrorResponse, DeliveriesByAttemptResponse>> DeliveriesByAttempt(this Client @this, DateTime from, DeliveriesByAttemptFilter filter)
    {
        var queryString = ToQueryString(from, filter);
        var requestUrl = $"/api/{@this.Version}/metrics/deliverability/attempt?{queryString}";
        return @this.Get<DeliveriesByAttemptResponse>(requestUrl);
    }
    
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
        var collection = new NameValueCollection { { "from", @from.ToString("s") } };

        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        collection.Add("industry_category", filter.IndustryCategory.ToString());

        collection.Add("mailbox_provider", filter.MailboxProvider.ToString());

        if(filter.Timezone != null)
        {
            collection.Add("timezone", filter.Timezone);
        }
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }
    
    private static string ToQueryString(MetricsFilter filter)
    {
        var collection = new NameValueCollection();

        if(filter.Match != null)
        {
            collection.Add("match", filter.Match);
        }
        if(filter.Limit != null)
        {
            collection.Add("limit", filter.Limit.ToString());
        }
        if(filter.From != null)
        {
            collection.Add("from", filter.From?.ToString("s"));
        }
        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Timezone != null)
        {
            collection.Add("timezone", filter.Timezone);
        }
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }
    
    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s")},  
            { "metrics", string.Concat(',', metrics)}  
        };

        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }
        if(filter.QueryFilters != null)
        {
            collection.Add("query_filters", filter.QueryFilters);
        }
        if(filter.Domains != null)
        {
            collection.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Campaigns != null)
        {
            collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        }
        if(filter.SubjectCampaigns != null)
        {
            collection.Add("subject_campaigns", string.Concat(',', filter.SubjectCampaigns));
        }
        if(filter.MailboxProviders != null)
        {
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }
        if(filter.MailboxProviderRegions != null)
        {
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }
        if(filter.Templates != null)
        {
            collection.Add("templates", string.Concat(',', filter.Templates));
        }
        if(filter.SendingIps != null)
        {
            collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }
        if(filter.IpPools != null)
        {
            collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        }
        if(filter.SendingDomains != null)
        {
            collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }
        if(filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }
        if(filter.Domains != null)
        {
            collection.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Precision != null)
        {
            collection.Add("precision", filter.Precision.ToString());
        }
        collection.Add("timezone", filter.Timezone);
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }
    private static string ToQueryString(DateTime from, DeliveriesByAttemptFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s")}  
        };

        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }
        if(filter.QueryFilters != null)
        {
            collection.Add("query_filters", filter.QueryFilters);
        }
        if(filter.Domains != null)
        {
            collection.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Campaigns != null)
        {
            collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        }
        if(filter.MailboxProviders != null)
        {
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }
        if(filter.MailboxProviderRegions != null)
        {
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }
        if(filter.Templates != null)
        {
            collection.Add("templates", string.Concat(',', filter.Templates));
        }
        if(filter.SendingIps != null)
        {
            collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }
        if(filter.IpPools != null)
        {
            collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        }
        if(filter.SendingDomains != null)
        {
            collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }
        if(filter.Bindings != null)
        {
            collection.Add("bindings", string.Concat(',', filter.Bindings));
        }
        if(filter.BindingGroups != null)
        {
            collection.Add("binding_groups", string.Concat(',', filter.BindingGroups));
        }
        if(filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }
        collection.Add("timezone", filter.Timezone);
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }

    private static string ToQueryString(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s")},  
            { "metrics", string.Concat(',', metrics)}  
        };

        return ToQueryString(collection, filter);
    }
    
    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(NameValueCollection collection, AggregateMetricsFilter filter)
    {
        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }
        if(filter.QueryFilters != null)
        {
            collection.Add("query_filters", filter.QueryFilters);
        }
        if(filter.Domains != null)
        {
            collection.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Campaigns != null)
        {
            collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        }
        if(filter.SubjectCampaigns != null)
        {
            collection.Add("subject_campaigns", string.Concat(',', filter.SubjectCampaigns));
        }
        if(filter.MailboxProviders != null)
        {
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }
        if(filter.MailboxProviderRegions != null)
        {
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }
        if(filter.Templates != null)
        {
            collection.Add("templates", string.Concat(',', filter.Templates));
        }
        if(filter.SendingIps != null)
        {
            collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }
        if(filter.IpPools != null)
        {
            collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        }
        if(filter.SendingDomains != null)
        {
            collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }
        if(filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }
        if(filter.Domains != null)
        {
            collection.Add("domains", string.Concat(',', filter.Domains));
        }
        if(filter.Precision != null)
        {
            collection.Add("precision", filter.Precision.ToString());
        }
        collection.Add("timezone", filter.Timezone);

        if(filter.Limit != null)
        {
            collection.Add("limit", filter.Limit.ToString());
        }
        if(filter.OrderBy != null)
        {
            collection.Add("order_by", filter.OrderBy.ToString());
        }
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }

    private static string ToQueryString(DateTime from, IList<Metric> metrics, string sample, AggregateMetricsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s")},  
            { "metrics", string.Concat(',', metrics)},  
            { "sample", sample }  
        };
        
        return ToQueryString(collection, filter);
    }
    private static string ToQueryString(DateTime from, IList<Metric> metrics, EngagementDetailsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s")},  
            { "metrics", string.Concat(',', metrics)}  
        };

        if(filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }
        if(filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }
        if(filter.QueryFilters != null)
        {
            collection.Add("query_filters", filter.QueryFilters);
        }
        collection.Add("timezone", filter.Timezone);
        
        if(filter.Campaigns != null)
        {
            collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        }
        if(filter.MailboxProviders != null)
        {
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }
        if(filter.MailboxProviderRegions != null)
        {
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }
        if(filter.Templates != null)
        {
            collection.Add("templates", string.Concat(',', filter.Templates));
        }
        if(filter.SendingDomains != null)
        {
            collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }
        if(filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }
        if(filter.Limit != null)
        {
            collection.Add("limit", filter.Limit.ToString());
        }
        
        return NameValueCollectionExtensions.ToQueryString(collection);
    }
}
