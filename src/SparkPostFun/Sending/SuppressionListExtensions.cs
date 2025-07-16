using System.Collections.Specialized;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;

namespace SparkPostFun.Sending;

public static class SuppressionListExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>>> BulkCreateOrUpdateSuppressions(BulkCreateOrUpdateSuppressions request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<BulkCreateOrUpdateSuppressionsResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>>> CreateOrUpdateSuppression(string recipient,
            CreateOrUpdateSuppressionRecipient request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<CreateOrUpdateSuppressionResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteSuppression(string recipient)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteSuppression(string recipient,
        DeleteSuppression request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}"
            select env.Client.Delete(requestUrl, request);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSuppressionResponse>>> RetrieveSuppression(string recipient)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}"
            select env.Client.Get<RetrieveSuppressionResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSuppressionResponse>>> RetrieveSuppression(string recipient,
            RetrieveSuppressionFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}?{queryString}"
            select env.Client.Get<RetrieveSuppressionResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSuppressionResponse>>> RetrieveSuppression(string recipient, int subaccountId)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}"
            select env.Client.GetWithSubaccount<RetrieveSuppressionResponse>(requestUrl, subaccountId);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSuppressionResponse>>> RetrieveSuppression(string recipient,
            RetrieveSuppressionFilter filter, int subaccountId)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/{recipient}?{queryString}"
            select env.Client.GetWithSubaccount<RetrieveSuppressionResponse>(requestUrl, subaccountId);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>>> RetrieveSuppressionSummary()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list/summary"
            select env.Client.Get<RetrieveSuppressionSummaryResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, SearchSuppressionsResponse>>> SearchSuppressions(SearchSuppressionsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/suppression-list?{queryString}"
            select env.Client.Get<SearchSuppressionsResponse>(requestUrl);
    }

    // ReSharper disable once CognitiveComplexity
    private static string ToQueryString(SearchSuppressionsFilter filter)
    {
        var collection = new NameValueCollection();

        if (filter.To != null) collection.Add("to", filter.To?.ToString("s"));

        if (filter.From != null) collection.Add("from", filter.To?.ToString("s"));

        if (filter.Domain != null) collection.Add("domain", filter.Domain);

        if (filter.Sources != null) collection.Add("sources", string.Concat(',', filter.Sources));

        if (filter.Types != null) collection.Add("types", string.Concat(',', filter.Types));

        if (filter.Description != null) collection.Add("description", filter.Description);

        if (filter.DescriptionStrict != null) collection.Add("description_strict", filter.DescriptionStrict.ToString());

        if (filter.Cursor != null) collection.Add("cursor", filter.Cursor);

        if (filter.PerPage != null) collection.Add("per_page", filter.PerPage.ToString());

        if (filter.Page != null) collection.Add("page", filter.Page.ToString());

        if (filter.Sort != null) collection.Add("sort", filter.Sort.ToString());

        return NameValueCollectionToQueryString(collection);
    }

    private static string ToQueryString(RetrieveSuppressionFilter filter)
    {
        var collection = new NameValueCollection();
        if (filter.Types != null) collection.Add("types", string.Concat(',', filter.Types));

        if (filter.Cursor != null) collection.Add("cursor", filter.Cursor);

        if (filter.PerPage != null) collection.Add("per_page", filter.PerPage.ToString());

        if (filter.Page != null) collection.Add("page", filter.Page.ToString());

        return NameValueCollectionToQueryString(collection);
    }
}