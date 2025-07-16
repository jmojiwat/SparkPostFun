using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending
{
    public static class IpPoolExtensions
    {
        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateIpPoolResponse>>> CreateIpPool(CreateIpPool request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/ip-pools"
                select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateIpPoolResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteIpPool(string id)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/ip-pools/{id}"
                select env.Client.Delete(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListIpPoolsResponse>>> ListIpPools()
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/ip-pools"
                select env.Client.Get<ListIpPoolsResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveIpPoolResponse>>> RetrieveIpPool(string id)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/ip-pools/{id}"
                select env.Client.Get<RetrieveIpPoolResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateIpPoolResponse>>> UpdateIpPool(string id, UpdateIpPool request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/ip-pools/{id}"
                select env.Client.Put(requestUrl, request)
                    .MapAsync(ToResponse<UpdateIpPoolResponse>);
        }
    }
}