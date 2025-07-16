using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Accounts;

public static class DataPrivacyExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>>> 
        AddRequestToBeForgotten(AddDataPrivacy request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/data-privacy/rtbf-request"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<DataPrivacyErrorResponse, AddDataPrivacyResponse>);
    }

    public static Task<Either<DataPrivacyErrorResponse, AddDataPrivacyResponse>> AddOptOut(this Client @this, AddDataPrivacy request)
    {
        var requestUrl = $"/api/{@this.Version}/data-privacy/opt-out-request";
        return @this.Post(requestUrl, request)
            .MapAsync(ToResponse<DataPrivacyErrorResponse, AddDataPrivacyResponse>);
    }
}