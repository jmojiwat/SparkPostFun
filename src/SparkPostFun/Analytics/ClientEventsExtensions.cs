using System.Collections.Specialized;
using LanguageExt;

namespace SparkPostFun.Analytics;

public static class ClientEventsExtensions
{
    public static Task<Either<ErrorResponse, EventsDocumentationResponse>> EventsDocumentation(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/message/documentation";
        return @this.Get<EventsDocumentationResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, EventsSamplesResponse>> EventsSamples(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/message/samples";
        return @this.Get<EventsSamplesResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, EventsSamplesResponse>> EventsSamples(this Client @this, string events)
    {
        var requestUrl = $"/api/{@this.Version}/events/message/samples?events={events}";
        return @this.Get<EventsSamplesResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrievePageEventsResponse>> RetrievePageEvents(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/message";
        return @this.Get<RetrievePageEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrievePageEventsResponse>> RetrievePageEvents(this Client @this, PageEventsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/events/message?{queryString}";
        return @this.Get<RetrievePageEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SearchIngestEventsResponse>> SearchIngestEvents(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/ingest";
        return @this.Get<SearchIngestEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SearchIngestEventsResponse>> SearchIngestEvents(this Client @this, SearchIngestEventsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/events/ingest?{queryString}";
        return @this.Get<SearchIngestEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SearchMessageEventsResponse>> SearchMessageEvents(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/message";
        return @this.Get<SearchMessageEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SearchMessageEventsResponse>> SearchMessageEvents(this Client @this, SearchMessageEventsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/events/message?{queryString}";
        return @this.Get<SearchMessageEventsResponse>(requestUrl);
    }


    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(SearchMessageEventsFilter filter)
    {
        var queryString = new NameValueCollection();

        if (filter.From != null)
        {
            queryString.Add("from", filter.From.ToString());
        }

        if (filter.To != null)
        {
            queryString.Add("to", filter.To.ToString());
        }

        if (filter.Cursor != null)
        {
            queryString.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            queryString.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Delimiter != null)
        {
            queryString.Add("delimiter", filter.Delimiter);
        }

        if (filter.EventIds != null)
        {
            queryString.Add("event_ids", string.Concat(',', filter.EventIds));
        }

        if (filter.Events != null)
        {
            queryString.Add("events", string.Concat(',', filter.Events));
        }

        if (filter.Recipients != null)
        {
            queryString.Add("recipients", string.Concat(',', filter.Recipients));
        }

        if (filter.RecipientDomains != null)
        {
            queryString.Add("recipient_domains", string.Concat(',', filter.RecipientDomains));
        }

        if (filter.FromAddresses != null)
        {
            queryString.Add("from_addresses", string.Concat(',', filter.FromAddresses));
        }

        if (filter.SendingDomains != null)
        {
            queryString.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }

        if (filter.Subjects != null)
        {
            queryString.Add("subjects", string.Concat(',', filter.Subjects));
        }

        if (filter.BounceClasses != null)
        {
            queryString.Add("bounce_classes", string.Concat(',', filter.BounceClasses));
        }

        if (filter.Reasons != null)
        {
            queryString.Add("reasons", string.Concat(',', filter.Reasons));
        }

        if (filter.Campaigns != null)
        {
            queryString.Add("campaigns", string.Concat(',', filter.Campaigns));
        }

        if (filter.Templates != null)
        {
            queryString.Add("templates", string.Concat(',', filter.Templates));
        }

        if (filter.SendingIps != null)
        {
            queryString.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }

        if (filter.IpPools != null)
        {
            queryString.Add("ip_pools", string.Concat(',', filter.IpPools));
        }

        if (filter.Subaccounts != null)
        {
            queryString.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }

        if (filter.Messages != null)
        {
            queryString.Add("messages", string.Concat(',', filter.Messages));
        }

        if (filter.Transmissions != null)
        {
            queryString.Add("transmissions", string.Concat(',', filter.Transmissions));
        }

        if (filter.MailboxProviders != null)
        {
            queryString.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }

        if (filter.MailboxProviderRegions != null)
        {
            queryString.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }

        if (filter.AbTests != null)
        {
            queryString.Add("ab_tests", string.Concat(',', filter.AbTests));
        }

        if (filter.AbTestVersions != null)
        {
            queryString.Add("ab_test_versions", string.Concat(',', filter.AbTestVersions));
        }


        return queryString.ToString();
    }

    private static string ToQueryString(SearchIngestEventsFilter filter)
    {
        var nameValueCollection = new NameValueCollection();

        if (filter.From != null)
        {
            nameValueCollection.Add("from", filter.From?.ToString("s"));
        }

        if (filter.To != null)
        {
            nameValueCollection.Add("to", filter.To?.ToString("s"));
        }

        if (filter.Cursor != null)
        {
            nameValueCollection.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            nameValueCollection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Delimiter != null)
        {
            nameValueCollection.Add("delimiter", filter.Delimiter);
        }

        if (filter.Events != null)
        {
            nameValueCollection.Add("events", string.Concat(',', filter.Events));
        }

        if (filter.EventIds != null)
        {
            nameValueCollection.Add("event_ids", string.Concat(',', filter.Events));
        }

        if (filter.BatchIds != null)
        {
            nameValueCollection.Add("batch_ids", string.Concat(',', filter.Events));
        }

        if (filter.Retryable != null)
        {
            nameValueCollection.Add("retryable", filter.Retryable.ToString());
        }

        if (filter.Subaccounts != null)
        {
            nameValueCollection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }

        return nameValueCollection.ToString();
    }

    private static string ToQueryString(PageEventsFilter filter)
    {
        var nameValueCollection = new NameValueCollection();

        if (filter.PerPage != null)
        {
            nameValueCollection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Cursor != null)
        {
            nameValueCollection.Add("cursor", filter.Cursor);
        }

        return nameValueCollection.ToString();
    }
}