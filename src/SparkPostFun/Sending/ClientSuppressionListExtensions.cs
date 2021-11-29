using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientSuppressionListExtensions
    {
        public static Task<Either<ErrorResponse, BulkCreateOrUpdateSuppressionsResponse>> BulkCreateOrUpdateSuppressions(this Client @this, IList<BulkCreateOrUpdateSuppressions> request)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<BulkCreateOrUpdateSuppressionsResponse>);
        }

        public static Task<Either<ErrorResponse, CreateOrUpdateSuppressionResponse>> CreateOrUpdateSuppression(this Client @this, string recipient, CreateOrUpdateSuppression request)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<CreateOrUpdateSuppressionResponse>);
        }

        public static Task<Either<ErrorResponse, RetrieveSuppressionResponse>> RetrieveSuppression(this Client @this, string recipient, IList<SuppressionType> types, string cursor, int page, int? perPage)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/{recipient}";
            return @this.Get<RetrieveSuppressionResponse>(requestUrl);
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

        public static Task<Either<ErrorResponse, SearchSuppressionsResponse>> SearchSuppressions(this Client @this, DateTime to, DateTime from, string domain, IList<SuppressionSource> sources, IList<SuppressionType> types, string description, bool descriptionStrict, string cursor, int page, int? perPage, SortOrder sort)
        {
            throw new NotImplementedException();

            var requestUrl = $"/api/{@this.Version}/suppression-list";
            return @this.Get<SearchSuppressionsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveSuppressionSummaryResponse>> RetrieveSuppressionSummary(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/suppression-list/summary";
            return @this.Get<RetrieveSuppressionSummaryResponse>(requestUrl);
        }

    }
}