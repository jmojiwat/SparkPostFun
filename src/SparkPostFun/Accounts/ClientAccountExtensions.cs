using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Accounts
{
    public static class ClientAccountExtensions
    {
        public static Task<Either<ErrorResponse, RetrieveAccountResponse>> RetrieveAccount(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/account";
            return @this.Get<RetrieveAccountResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveAccountResponse>> RetrieveAccount(this Client @this, string include)
        {
            var requestUrl = $"/api/{@this.Version}/account?include={include}";
            return @this.Get<RetrieveAccountResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, UpdateAccountResponse>> UpdateAccount(this Client @this, int id, UpdateAccount request)
        {
            var requestUrl = $"/api/{@this.Version}/account/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateAccountResponse>);
        }
    }
}