using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientAbTestingExtensions
    {
        public static Task<Either<ErrorResponse, Unit>> CancelAbTest(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/{id}/cancel";
            return @this.Post(requestUrl, new CancelAbTest())
                .MapAsync(ToResponse<Unit>);
        }

        public static Task<Either<ErrorResponse, CreateAbTestResponse>> CreateAbTest(this Client @this, CreateAbTest request)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateAbTestResponse>);
        }

        public static Task<Either<ErrorResponse, CreateAbTestDraftResponse>> CreateAbTestDraft(this Client @this, CreateAbTestDraft request)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/draft";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateAbTestDraftResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteAbTest(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/{id}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteAbTestDraft(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/draft/{id}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListAbTestsResponse>> ListAbTests(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test";
            return @this.Get<ListAbTestsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListAbTestsResponse>> ListAbTests(this Client @this, AbTestingStatus status)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test?status={status}";
            return @this.Get<ListAbTestsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveAbTestResponse>> RetrieveAbTest(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/{id}";
            return @this.Get<RetrieveAbTestResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveAbTestResponse>> RetrieveAbTest(this Client @this, string id, int version)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/{id}?{version}";
            return @this.Get<RetrieveAbTestResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveAbTestDraftResponse>> RetrieveAbTestDraft(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/draft/{id}";
            return @this.Get<RetrieveAbTestDraftResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, ScheduleAbTestDraftResponse>> ScheduleAbTestDraft(this Client @this, string id, ScheduleAbTestDraft request)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/draft/{id}/schedule";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<ScheduleAbTestDraftResponse>);
        }

        public static Task<Either<ErrorResponse, UpdateAbTestResponse>> UpdateAbTest(this Client @this, string id, UpdateAbTest request)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAbTestResponse>);
        }

        public static Task<Either<ErrorResponse, UpdateAbTestResponse>> UpdateAbTestDraft(this Client @this, string id, UpdateAbTest request)
        {
            var requestUrl = $"/api/{@this.Version}/ab-test/draft/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAbTestResponse>);
        }
    }
}