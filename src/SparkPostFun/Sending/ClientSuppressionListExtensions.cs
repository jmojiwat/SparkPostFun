using System.Collections.Specialized;
using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending;

public static class ClientSuppressionListExtensions
{
    public static Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>> BulkCreateOrUpdateSuppressions(this Client @this,
        BulkCreateOrUpdateSuppressions request)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<BulkCreateOrUpdateSuppressionsResponse>);
    }

    public static Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>> CreateOrUpdateSuppression(this Client @this, string recipient,
        CreateOrUpdateSuppression request)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
        return @this.Put(requestUrl, request)
            .MapAsync(ToResponse<CreateOrUpdateSuppressionResponse>);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteSuppression(this Client @this, string id)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/{id}";
        return @this.Delete(requestUrl);
    }

    public static Task<Either<ErrorResponse, Unit>> DeleteSuppression(this Client @this, string id, DeleteSuppression request)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/{id}";
        return @this.Delete(requestUrl, request);
    }

    public static Task<Either<ErrorResponse, RetrieveSuppressionResponse>> RetrieveSuppression(this Client @this, string recipient)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
        return @this.Get<RetrieveSuppressionResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveSuppressionResponse>> RetrieveSuppression(this Client @this, string recipient,
        RetrieveSuppressionFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}?{queryString}";
        return @this.Get<RetrieveSuppressionResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, RetrieveSuppressionResponse>> RetrieveSuppression(this Client @this, string recipient, int subaccountId)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
        return @this.GetWithSubaccount<RetrieveSuppressionResponse>(requestUrl, subaccountId);
    }

    public static Task<Either<ErrorResponse, RetrieveSuppressionResponse>> RetrieveSuppression(this Client @this, string recipient,
        RetrieveSuppressionFilter filter, int subaccountId)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}?{queryString}";
        return @this.GetWithSubaccount<RetrieveSuppressionResponse>(requestUrl, subaccountId);
    }

    public static Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>> RetrieveSuppressionSummary(this Client @this)
    {
        var requestUrl = $"/api/{@this.Version}/suppression-list/summary";
        return @this.Get<RetrieveSuppressionSummaryResponse>(requestUrl);
    }

    public static Task<Either<ErrorResponse, SearchSuppressionsResponse>> SearchSuppressions(this Client @this, SearchSuppressionsFilter filter)
    {
        var queryString = ToQueryString(filter);
        var requestUrl = $"/api/{@this.Version}/suppression-list?{queryString}";
        return @this.Get<SearchSuppressionsResponse>(requestUrl);
    }

    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(SearchSuppressionsFilter filter)
    {
        var queryString = new NameValueCollection();

        if (filter.To != null)
        {
            queryString.Add("to", filter.To?.ToString("s"));
        }

        if (filter.From != null)
        {
            queryString.Add("from", filter.To?.ToString("s"));
        }

        if (filter.Domain != null)
        {
            queryString.Add("domain", filter.Domain);
        }

        if (filter.Sources != null)
        {
            queryString.Add("sources", string.Concat(',', filter.Sources));
        }

        if (filter.Types != null)
        {
            queryString.Add("types", string.Concat(',', filter.Types));
        }

        if (filter.Description != null)
        {
            queryString.Add("description", filter.Description);
        }

        if (filter.DescriptionStrict != null)
        {
            queryString.Add("description_strict", filter.DescriptionStrict.ToString());
        }

        if (filter.Cursor != null)
        {
            queryString.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            queryString.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Page != null)
        {
            queryString.Add("page", filter.Page.ToString());
        }

        if (filter.Sort != null)
        {
            queryString.Add("sort", filter.Sort.ToString());
        }

        return queryString.ToString();
    }

    private static string ToQueryString(RetrieveSuppressionFilter filter)
    {
        var queryString = new NameValueCollection();
        if (filter.Types != null)
        {
            queryString.Add("types", string.Concat(',', filter.Types));
        }

        if (filter.Cursor != null)
        {
            queryString.Add("cursor", filter.Cursor);
        }

        if (filter.PerPage != null)
        {
            queryString.Add("per_page", filter.PerPage.ToString());
        }

        if (filter.Page != null)
        {
            queryString.Add("page", filter.Page.ToString());
        }

        return queryString.ToString();
    }
}