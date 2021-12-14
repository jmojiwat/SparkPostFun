using LanguageExt;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientIpPoolExtensions
    {
        public static Task<Either<ErrorResponse, CreateIpPoolResponse>> CreateIpPool(this Client @this, CreateIpPool request)
        {
            var requestUrl = $"/api/{@this.Version}/ip-pools";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateIpPoolResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteIpPool(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ip-pools/{id}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListIpPoolsResponse>> ListIpPools(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/ip-pools";
            return @this.Get<ListIpPoolsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveIpPoolResponse>> RetrieveIpPool(this Client @this, string id)
        {
            var requestUrl = $"/api/{@this.Version}/ip-pools/{id}";
            return @this.Get<RetrieveIpPoolResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, UpdateIpPoolResponse>> UpdateIpPool(this Client @this, string id, UpdateIpPool request)
        {
            var requestUrl = $"/api/{@this.Version}/ip-pools/{id}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateIpPoolResponse>);
        }
    }
}