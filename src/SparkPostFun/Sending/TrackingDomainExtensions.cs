using System.Collections.Specialized;
using System.Collections.Generic;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;
using static LanguageExt.Prelude;

namespace SparkPostFun.Sending
{
    public static class TrackingDomainExtensions
    {
        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateTrackingDomainResponse>>>
            CreateTrackingDomain(CreateTrackingDomain request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains"
                select env.Client.Post(requestUrl, request)
                    .MapAsync(ToResponse<CreateTrackingDomainResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteTrackingDomain(
            string domain)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains/{domain}"
                select env.Client.Delete(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSendingDomainsResponse>>>
            ListTrackingDomains() =>
            ListTrackingDomains(null, null);

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSendingDomainsResponse>>>
            ListTrackingDomains(bool? @default, IList<int> subaccounts)
        {
            var collection = new NameValueCollection();
            if (@default != null)
            {
                collection.Add("default", @default.ToString());
            }

            if (subaccounts != null)
            {
                collection.Add("subaccounts", string.Join(",", subaccounts));
            }

            var queryString = NameValueCollectionToQueryString(collection);
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains?{queryString}"
                select env.Client.Get<ListSendingDomainsResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveTrackingDomainResponse>>>
            RetrieveTrackingDomain(string domain)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains/{domain}"
                select env.Client.Get<RetrieveTrackingDomainResponse>(requestUrl);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateTrackingDomainResponse>>>
            UpdateTrackingDomain(string domain,
                UpdateTrackingDomain request)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains/{domain}"
                select env.Client.Put(requestUrl, request)
                    .MapAsync(ToResponse<UpdateTrackingDomainResponse>);
        }

        public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, VerifyTrackingDomainResponse>>>
            VerifyTrackingDomain(string domain)
        {
            return
                from env in ask<SparkPostEnvironment>()
                let requestUrl = $"/api/{env.Version}/tracking-domains/{domain}/verify"
                select env.Client.Post(requestUrl)
                    .MapAsync(ToResponse<VerifyTrackingDomainResponse>);
        }
    }
}