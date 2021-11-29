using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Accounts
{
    public static class ClientDataPrivacyExtensions
    {
        public static Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> AddRequestToBeForgotten(this Client @this, AddDataPrivacy request)
        {
            var requestUrl = $"/api/{@this.Version}/data-privacy/rtbf-request";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<DataPrivacyErrorResponse, AddDataPrivacyResponse>);
        }

        public static Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> AddOptOut(this Client @this, AddDataPrivacy request)
        {
            var requestUrl = $"/api/{@this.Version}/data-privacy/opt-out-request";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<DataPrivacyErrorResponse, AddDataPrivacyResponse>);
        }
    }
}