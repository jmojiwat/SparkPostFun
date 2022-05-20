using System.Collections.Specialized;
using LanguageExt;
using SparkPostFun.Infrastructure;

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

    public static Task<Either<ErrorResponse, RetrievePageEventsResponse>> RetrievePage(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/events/message";
        return @this.Get<RetrievePageEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrievePageEventsResponse>> RetrievePage(this Client @this, PageFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/events/message?{queryString}";
        return @this.Get<RetrievePageEventsResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrievePageEventsResponse>> RetrieveFirstPage(this Client @this, FirstPageFilter filter)
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
        var collection = new NameValueCollection();

        if (filter.From != null)
        {
            collection.Add("from", filter.From.ToString());
        }

        if (filter.To != null)
        {
            collection.Add("to", filter.To.ToString());
        }

        if (filter.Cursor != null)
        {
            collection.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            collection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }

        if (filter.EventIds != null)
        {
            collection.Add("event_ids", string.Concat(',', filter.EventIds));
        }

        if (filter.Events != null)
        {
            collection.Add("events", string.Concat(',', filter.Events));
        }

        if (filter.Recipients != null)
        {
            collection.Add("recipients", string.Concat(',', filter.Recipients));
        }

        if (filter.RecipientDomains != null)
        {
            collection.Add("recipient_domains", string.Concat(',', filter.RecipientDomains));
        }

        if (filter.FromAddresses != null)
        {
            collection.Add("from_addresses", string.Concat(',', filter.FromAddresses));
        }

        if (filter.SendingDomains != null)
        {
            collection.Add("sending_domains", string.Concat(',', filter.SendingDomains));
        }

        if (filter.Subjects != null)
        {
            collection.Add("subjects", string.Concat(',', filter.Subjects));
        }

        if (filter.BounceClasses != null)
        {
            collection.Add("bounce_classes", string.Concat(',', filter.BounceClasses));
        }

        if (filter.Reasons != null)
        {
            collection.Add("reasons", string.Concat(',', filter.Reasons));
        }

        if (filter.Campaigns != null)
        {
            collection.Add("campaigns", string.Concat(',', filter.Campaigns));
        }

        if (filter.Templates != null)
        {
            collection.Add("templates", string.Concat(',', filter.Templates));
        }

        if (filter.SendingIps != null)
        {
            collection.Add("sending_ips", string.Concat(',', filter.SendingIps));
        }

        if (filter.IpPools != null)
        {
            collection.Add("ip_pools", string.Concat(',', filter.IpPools));
        }

        if (filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }

        if (filter.Messages != null)
        {
            collection.Add("messages", string.Concat(',', filter.Messages));
        }

        if (filter.Transmissions != null)
        {
            collection.Add("transmissions", string.Concat(',', filter.Transmissions));
        }

        if (filter.MailboxProviders != null)
        {
            collection.Add("mailbox_providers", string.Concat(',', filter.MailboxProviders));
        }

        if (filter.MailboxProviderRegions != null)
        {
            collection.Add("mailbox_provider_regions", string.Concat(',', filter.MailboxProviderRegions));
        }

        if (filter.AbTests != null)
        {
            collection.Add("ab_tests", string.Concat(',', filter.AbTests));
        }

        if (filter.AbTestVersions != null)
        {
            collection.Add("ab_test_versions", string.Concat(',', filter.AbTestVersions));
        }

        return NameValueCollectionExtensions.ToQueryString(collection);
    }

    private static string ToQueryString(SearchIngestEventsFilter filter)
    {
        var collection = new NameValueCollection();

        if (filter.From != null)
        {
            collection.Add("from", filter.From?.ToString("s"));
        }

        if (filter.To != null)
        {
            collection.Add("to", filter.To?.ToString("s"));
        }

        if (filter.Cursor != null)
        {
            collection.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            collection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Delimiter != null)
        {
            collection.Add("delimiter", filter.Delimiter);
        }

        if (filter.Events != null)
        {
            collection.Add("events", string.Concat(',', filter.Events));
        }

        if (filter.EventIds != null)
        {
            collection.Add("event_ids", string.Concat(',', filter.Events));
        }

        if (filter.BatchIds != null)
        {
            collection.Add("batch_ids", string.Concat(',', filter.Events));
        }

        if (filter.Retryable != null)
        {
            collection.Add("retryable", filter.Retryable.ToString());
        }

        if (filter.Subaccounts != null)
        {
            collection.Add("subaccounts", string.Concat(',', filter.Subaccounts));
        }

        return NameValueCollectionExtensions.ToQueryString(collection);
    }

    private static string ToQueryString(PageFilter filter)
    {
        var collection = new NameValueCollection();

        if (filter.PerPage != null)
        {
            collection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Cursor != null)
        {
            collection.Add("cursor", filter.Cursor);
        }

        return NameValueCollectionExtensions.ToQueryString(collection);
    }

    private static string ToQueryString(FirstPageFilter filter)
    {
        var collection = new NameValueCollection();

        if (filter.PerPage != null)
        {
            collection.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Cursor != null)
        {
            collection.Add("cursor", filter.Cursor);
        }

        return NameValueCollectionExtensions.ToQueryString(collection);
    }
}