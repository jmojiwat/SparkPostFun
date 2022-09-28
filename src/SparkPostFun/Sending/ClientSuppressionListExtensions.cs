using System.Collections.Specialized;
using System.Threading.Tasks;
using LanguageExt;
using SparkPostFun.Infrastructure;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
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
            CreateOrUpdateSuppressionRecipient request)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<CreateOrUpdateSuppressionResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteSuppression(this Client @this, string recipient)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteSuppression(this Client @this, string recipient, DeleteSuppression request)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
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
            var collection = new NameValueCollection();

            if (filter.To != null)
            {
                collection.Add("to", filter.To?.ToString("s"));
            }

            if (filter.From != null)
            {
                collection.Add("from", filter.To?.ToString("s"));
            }

            if (filter.Domain != null)
            {
                collection.Add("domain", filter.Domain);
            }

            if (filter.Sources != null)
            {
                collection.Add("sources", string.Concat(',', filter.Sources));
            }

            if (filter.Types != null)
            {
                collection.Add("types", string.Concat(',', filter.Types));
            }

            if (filter.Description != null)
            {
                collection.Add("description", filter.Description);
            }

            if (filter.DescriptionStrict != null)
            {
                collection.Add("description_strict", filter.DescriptionStrict.ToString());
            }

            if (filter.Cursor != null)
            {
                collection.Add("cursor", filter.Cursor);
            }

            if (filter.PerPage != null)
            {
                collection.Add("per_page", filter.PerPage.ToString());
            }

            if (filter.Page != null)
            {
                collection.Add("page", filter.Page.ToString());
            }

            if (filter.Sort != null)
            {
                collection.Add("sort", filter.Sort.ToString());
            }

            return NameValueCollectionExtensions.ToQueryString(collection);
        }

        private static string ToQueryString(RetrieveSuppressionFilter filter)
        {
            var collection = new NameValueCollection();
            if (filter.Types != null)
            {
                collection.Add("types", string.Concat(',', filter.Types));
            }

            if (filter.Cursor != null)
            {
                collection.Add("cursor", filter.Cursor);
            }

            if (filter.PerPage != null)
            {
                collection.Add("per_page", filter.PerPage.ToString());
            }

            if (filter.Page != null)
            {
                collection.Add("page", filter.Page.ToString());
            }

            return NameValueCollectionExtensions.ToQueryString(collection);
        }
    }
}