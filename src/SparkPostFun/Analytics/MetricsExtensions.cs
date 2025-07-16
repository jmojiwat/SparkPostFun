using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using LanguageExt;
using SparkPostFun.Infrastructure;
using static LanguageExt.Prelude;

namespace SparkPostFun.Analytics;

public static class MetricsExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, AdvancedQueryJsonSchemaResponse>>> AdvancedQueryJsonSchema()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/query-filters-schema"
            select env.Client.Get<AdvancedQueryJsonSchemaResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DiscoverabilityLinksResponse>>> DiscoverabilityLinks()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics"
            select env.Client.Get<DiscoverabilityLinksResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DiscoverabilityLinksResponse>>> MetricsSummary(DateTime from, IList<Metric> metrics)
    {
        return MetricsSummary(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DiscoverabilityLinksResponse>>> MetricsSummary(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability?{queryString}"
            select env.Client.Get<DiscoverabilityLinksResponse>(requestUrl);
    }

    // todo: complete implementation
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByRecipientDomainResponse>>>
        MetricsByRecipientDomain(DateTime from, IList<Metric> metrics)
    {
        return MetricsByRecipientDomain(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByRecipientDomainResponse>>>
        MetricsByRecipientDomain(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/domain?{queryString}"
            select env.Client.Get<MetricsByRecipientDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySendingIpResponse>>>
        MetricsBySendingIp(DateTime from, IList<Metric> metrics)
    {
        return MetricsBySendingIp(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySendingIpResponse>>>
        MetricsBySendingIp(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/sending-ip?{queryString}"
            select env.Client.Get<MetricsBySendingIpResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByIpPoolResponse>>> MetricsByIpPool(
        DateTime from, IList<Metric> metrics)
    {
        return MetricsByIpPool(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByIpPoolResponse>>> MetricsByIpPool(
        DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/ip-pool?{queryString}"
            select env.Client.Get<MetricsByIpPoolResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySendingDomainResponse>>>
        MetricsBySendingDomain(DateTime from, IList<Metric> metrics)
    {
        return MetricsBySendingDomain(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySendingDomainResponse>>>
        MetricsBySendingDomain(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/sending-domain?{queryString}"
            select env.Client.Get<MetricsBySendingDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySubaccountResponse>>>
        MetricsBySubaccount(DateTime from, IList<Metric> metrics)
    {
        return MetricsBySubaccount(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySubaccountResponse>>>
        MetricsBySubaccount(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/subaccount?{queryString}"
            select env.Client.Get<MetricsBySubaccountResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByCampaignResponse>>>
        MetricsByCampaign(DateTime from, IList<Metric> metrics, string sample)
    {
        return MetricsByCampaign(from, metrics, sample, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByCampaignResponse>>>
        MetricsByCampaign(DateTime from, IList<Metric> metrics, string sample, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, sample, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/campaign?{queryString}"
            select env.Client.Get<MetricsByCampaignResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByTemplateResponse>>>
        MetricsByTemplate(DateTime from, IList<Metric> metrics)
    {
        return MetricsByTemplate(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByTemplateResponse>>>
        MetricsByTemplate(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/template?{queryString}"
            select env.Client.Get<MetricsByTemplateResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySubjectCampaignResponse>>>
        MetricsBySubjectCampaign(DateTime from, IList<Metric> metrics)
    {
        return MetricsBySubjectCampaign(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsBySubjectCampaignResponse>>>
        MetricsBySubjectCampaign(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/subject-campaign?{queryString}"
            select env.Client.Get<MetricsBySubjectCampaignResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByWatchedDomainResponse>>>
        MetricsByWatchedDomain(DateTime from, IList<Metric> metrics)
    {
        return MetricsByWatchedDomain(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByWatchedDomainResponse>>>
        MetricsByWatchedDomain(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/watched-domain?{queryString}"
            select env.Client.Get<MetricsByWatchedDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByMailboxProviderResponse>>>
        MetricsByMailboxProvider(DateTime from, IList<Metric> metrics)
    {
        return MetricsByMailboxProvider(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByMailboxProviderResponse>>>
        MetricsByMailboxProvider(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/mailbox-provider?{queryString}"
            select env.Client.Get<MetricsByMailboxProviderResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByMailboxProviderRegionResponse>>>
        MetricsByMailboxProviderRegion(DateTime from, IList<Metric> metrics)
    {
        return MetricsByMailboxProviderRegion(from, metrics, new AggregateMetricsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MetricsByMailboxProviderRegionResponse>>>
        MetricsByMailboxProviderRegion(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/mailbox-provider-region?{queryString}"
            select env.Client.Get<MetricsByMailboxProviderRegionResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, TimeSeriesMetricsResponse>>>
        TimeSeriesMetrics(DateTime from, IList<Metric> metrics)
    {
        return TimeSeriesMetrics(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, TimeSeriesMetricsResponse>>>
        TimeSeriesMetrics(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/time-series?{queryString}"
            select env.Client.Get<TimeSeriesMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceReasonMetricsResponse>>>
        BounceReasonMetrics(DateTime from, IList<Metric> metrics)
    {
        return BounceReasonMetrics(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceReasonMetricsResponse>>>
        BounceReasonMetrics(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/bounce-reason?{queryString}"
            select env.Client.Get<BounceReasonMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceReasonMetricsByDomainResponse>>>
        BounceReasonMetricsByDomain(DateTime from, IList<Metric> metrics)
    {
        return BounceReasonMetricsByDomain(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceReasonMetricsByDomainResponse>>>
        BounceReasonMetricsByDomain(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/bounce-reason/domain?{queryString}"
            select env.Client.Get<BounceReasonMetricsByDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceClassificationMetricsResponse>>>
        BounceClasificationMetrics(DateTime from, IList<Metric> metrics)
    {
        return BounceClasificationMetrics(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BounceClassificationMetricsResponse>>>
        BounceClasificationMetrics(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/bounce-classification?{queryString}"
            select env.Client.Get<BounceClassificationMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RejectionReasonMetricsResponse>>>
        RejectionReasonMetrics(DateTime from, IList<Metric> metrics)
    {
        return RejectionReasonMetrics(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RejectionReasonMetricsResponse>>>
        RejectionReasonMetrics(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/rejection-reason?{queryString}"
            select env.Client.Get<RejectionReasonMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RejectionReasonMetricsByDomainResponse>>>
        RejectionReasonMetricsByDomain(DateTime from, IList<Metric> metrics)
    {
        return RejectionReasonMetricsByDomain(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RejectionReasonMetricsByDomainResponse>>>
        RejectionReasonMetricsByDomain(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/rejection-reason/domain?{queryString}"
            select env.Client.Get<RejectionReasonMetricsByDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DelayReasonMetricsResponse>>>
        DelayReasonMetrics(DateTime from, IList<Metric> metrics)
    {
        return DelayReasonMetrics(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DelayReasonMetricsResponse>>>
        DelayReasonMetrics(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/delay-reason?{queryString}"
            select env.Client.Get<DelayReasonMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DelayReasonMetricsByDomainResponse>>>
        DelayReasonMetricsByDomain(DateTime from, IList<Metric> metrics)
    {
        return DelayReasonMetricsByDomain(from, metrics, new MetricsSummaryFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DelayReasonMetricsByDomainResponse>>>
        DelayReasonMetricsByDomain(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/delay-reason/domain?{queryString}"
            select env.Client.Get<DelayReasonMetricsByDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, EngagementDetailsResponse>>>
        EngagementDetails(DateTime from, IList<Metric> metrics)
    {
        return EngagementDetails(from, metrics, new EngagementDetailsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, EngagementDetailsResponse>>>
        EngagementDetails(DateTime from, IList<Metric> metrics, EngagementDetailsFilter filter)
    {
        var queryString = ToQueryString(from, metrics, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/link-name?{queryString}"
            select env.Client.Get<EngagementDetailsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DeliveriesByAttemptResponse>>>
        DeliveriesByAttempt(DateTime from)
    {
        return DeliveriesByAttempt(from, new DeliveriesByAttemptFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DeliveriesByAttemptResponse>>>
        DeliveriesByAttempt(DateTime from, DeliveriesByAttemptFilter filter)
    {
        var queryString = ToQueryString(from, filter);
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/deliverability/attempt?{queryString}"
            select env.Client.Get<DeliveriesByAttemptResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, IpPoolsMetricsResponse>>> IpPoolsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/ip-pools"
            select env.Client.Get<IpPoolsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, IpPoolsMetricsResponse>>> IpPoolsMetrics(
        MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/ip-pools?{queryString}"
            select env.Client.Get<IpPoolsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SendingIpsMetricsResponse>>>
        SendingIpsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/sending-ips"
            select env.Client.Get<SendingIpsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SendingIpsMetricsResponse>>>
        SendingIpsMetrics(MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/sending-ips?{queryString}"
            select env.Client.Get<SendingIpsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MailboxProviderRegionsMetricsResponse>>>
        MailboxProviderRegionsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/mailbox-provider-regions"
            select env.Client.Get<MailboxProviderRegionsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MailboxProviderRegionsMetricsResponse>>>
        MailboxProviderRegionsMetrics(MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/mailbox-provider-regions?{queryString}"
            select env.Client.Get<MailboxProviderRegionsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MailboxProvidersMetricsResponse>>>
        MailboxProvidersMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/mailbox-providers"
            select env.Client.Get<MailboxProvidersMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, MailboxProvidersMetricsResponse>>>
        MailboxProvidersMetrics(MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/mailbox-providers?{queryString}"
            select env.Client.Get<MailboxProvidersMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CampaignsMetricsResponse>>> CampaignsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/campaigns"
            select env.Client.Get<CampaignsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CampaignsMetricsResponse>>> CampaignsMetrics(
        MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/campaigns?{queryString}"
            select env.Client.Get<CampaignsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, TemplatesMetricsResponse>>> TemplatesMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/templates"
            select env.Client.Get<TemplatesMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, TemplatesMetricsResponse>>> TemplatesMetrics(
        MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/templates?{queryString}"
            select env.Client.Get<TemplatesMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DomainsMetricsResponse>>> DomainsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/domains"
            select env.Client.Get<DomainsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, DomainsMetricsResponse>>> DomainsMetrics(
        MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/domains?{queryString}"
            select env.Client.Get<DomainsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SubjectCampaignsMetricsResponse>>>
        SubjectCampaignsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/subject-campaigns"
            select env.Client.Get<SubjectCampaignsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SubjectCampaignsMetricsResponse>>>
        SubjectCampaignsMetrics(MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/subject-campaigns?{queryString}"
            select env.Client.Get<SubjectCampaignsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SendingDomainsMetricsResponse>>>
        SendingDomainsMetrics()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/sending-domains"
            select env.Client.Get<SendingDomainsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SendingDomainsMetricsResponse>>>
        SendingDomainsMetrics(MetricsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/sending-domains?{queryString}"
            select env.Client.Get<SendingDomainsMetricsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, InboxRateMetricsResponse>>>
        InboxRateMetrics(DateTime from)
    {
        return InboxRateMetrics(from, new InboxRateFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, InboxRateMetricsResponse>>> InboxRateMetrics(
        DateTime from, InboxRateFilter filter)
    {
        var queryString = ToQueryString(from, filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/metrics/benchmarks/inbox-rate?{queryString}"
            select env.Client.Get<InboxRateMetricsResponse>(requestUrl);
    }

    private static string ToQueryString(DateTime from, InboxRateFilter filter)
    {
        var collection = new NameValueCollection { { "from", from.ToString("s") } };

        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        collection.Add("industry_category", filter.IndustryCategory.ToString());

        collection.Add("mailbox_provider", filter.MailboxProvider.ToString());

        if (filter.Timezone != null) collection.Add("timezone", filter.Timezone);

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }

    private static string ToQueryString(MetricsFilter filter)
    {
        var collection = new NameValueCollection();

        if (filter.Match != null) collection.Add("match", filter.Match);
        if (filter.Limit != null) collection.Add("limit", filter.Limit.ToString());
        if (filter.From != null) collection.Add("from", filter.From?.ToString("s"));
        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        if (filter.Timezone != null) collection.Add("timezone", filter.Timezone);

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }

    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(DateTime from, IList<Metric> metrics, MetricsSummaryFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s") },
            { "metrics", string.Concat(',', metrics) }
        };

        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        if (filter.Delimiter != null) collection.Add("delimiter", filter.Delimiter);
        if (filter.QueryFilters != null) collection.Add("query_filters", filter.QueryFilters);
        if (filter.Domains != null) collection.Add("domains", string.Concat(',', filter.Domains));
        if (filter.Campaigns != null) collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        if (filter.SubjectCampaigns != null)
            collection.Add("subject_campaigns", string.Concat(',', filter.SubjectCampaigns));
        if (filter.MailboxProviders != null)
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        if (filter.MailboxProviderRegions != null)
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        if (filter.Templates != null) collection.Add("templates", string.Concat(',', filter.Templates));
        if (filter.SendingIps != null) collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        if (filter.IpPools != null) collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        if (filter.SendingDomains != null) collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        if (filter.Subaccounts != null) collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        if (filter.Domains != null) collection.Add("domains", string.Concat(',', filter.Domains));
        if (filter.Precision != null) collection.Add("precision", filter.Precision.ToString());
        collection.Add("timezone", filter.Timezone);

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }

    private static string ToQueryString(DateTime from, DeliveriesByAttemptFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s") }
        };

        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        if (filter.Delimiter != null) collection.Add("delimiter", filter.Delimiter);
        if (filter.QueryFilters != null) collection.Add("query_filters", filter.QueryFilters);
        if (filter.Domains != null) collection.Add("domains", string.Concat(',', filter.Domains));
        if (filter.Campaigns != null) collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        if (filter.MailboxProviders != null)
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        if (filter.MailboxProviderRegions != null)
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        if (filter.Templates != null) collection.Add("templates", string.Concat(',', filter.Templates));
        if (filter.SendingIps != null) collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        if (filter.IpPools != null) collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        if (filter.SendingDomains != null) collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        if (filter.Bindings != null) collection.Add("bindings", string.Concat(',', filter.Bindings));
        if (filter.BindingGroups != null) collection.Add("binding_groups", string.Concat(',', filter.BindingGroups));
        if (filter.Subaccounts != null) collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        collection.Add("timezone", filter.Timezone);

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }

    private static string ToQueryString(DateTime from, IList<Metric> metrics, AggregateMetricsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s") },
            { "metrics", string.Concat(',', metrics) }
        };

        return ToQueryString(collection, filter);
    }

    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(NameValueCollection collection, AggregateMetricsFilter filter)
    {
        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        if (filter.Delimiter != null) collection.Add("delimiter", filter.Delimiter);
        if (filter.QueryFilters != null) collection.Add("query_filters", filter.QueryFilters);
        if (filter.Domains != null) collection.Add("domains", string.Concat(',', filter.Domains));
        if (filter.Campaigns != null) collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        if (filter.SubjectCampaigns != null)
            collection.Add("subject_campaigns", string.Concat(',', filter.SubjectCampaigns));
        if (filter.MailboxProviders != null)
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        if (filter.MailboxProviderRegions != null)
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        if (filter.Templates != null) collection.Add("templates", string.Concat(',', filter.Templates));
        if (filter.SendingIps != null) collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        if (filter.IpPools != null) collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        if (filter.SendingDomains != null) collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        if (filter.Subaccounts != null) collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        if (filter.Domains != null) collection.Add("domains", string.Concat(',', filter.Domains));
        if (filter.Precision != null) collection.Add("precision", filter.Precision.ToString());
        collection.Add("timezone", filter.Timezone);

        if (filter.Limit != null) collection.Add("limit", filter.Limit.ToString());
        if (filter.OrderBy != null) collection.Add("order_by", filter.OrderBy.ToString());

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }

    private static string ToQueryString(DateTime from, IList<Metric> metrics, string sample,
        AggregateMetricsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s") },
            { "metrics", string.Concat(',', metrics) },
            { "sample", sample }
        };

        return ToQueryString(collection, filter);
    }

    private static string ToQueryString(DateTime from, IList<Metric> metrics, EngagementDetailsFilter filter)
    {
        var collection = new NameValueCollection
        {
            { "from", from.ToString("s") },
            { "metrics", string.Concat(',', metrics) }
        };

        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));
        if (filter.Delimiter != null) collection.Add("delimiter", filter.Delimiter);
        if (filter.QueryFilters != null) collection.Add("query_filters", filter.QueryFilters);
        collection.Add("timezone", filter.Timezone);

        if (filter.Campaigns != null) collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        if (filter.MailboxProviders != null)
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        if (filter.MailboxProviderRegions != null)
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        if (filter.Templates != null) collection.Add("templates", string.Concat(',', filter.Templates));
        if (filter.SendingDomains != null) collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        if (filter.Subaccounts != null) collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        if (filter.Limit != null) collection.Add("limit", filter.Limit.ToString());

        return NameValueCollectionExtensions.NameValueCollectionToQueryString(collection);
    }
}