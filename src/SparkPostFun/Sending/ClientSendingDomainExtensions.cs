using System.Collections.Specialized;
using System.Threading.Tasks;
using LanguageExt;
using SparkPostFun.Infrastructure;
using static SparkPostFun.ClientExtensions;

namespace SparkPostFun.Sending
{
    public static class ClientSendingDomainExtensions
    {
        public static Task<Either<ErrorResponse, CreateSendingDomainResponse>> CreateSendingDomain(this Client @this, CreateSendingDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateSendingDomainResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteSendingDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListSendingDomains(this Client @this) =>
            ListSendingDomains(@this, new SendingDomainsFilter());

        public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListSendingDomains(this Client @this, SendingDomainsFilter filter)
        {
            var queryString = ToQueryString(filter);

            var requestUrl = $"/api/{@this.Version}/sending-domains?{queryString}";
            return @this.Get<ListSendingDomainsResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, RetrieveSendingDomainResponse>> RetrieveSendingDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Get<RetrieveSendingDomainResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, UpdateSendingDomainResponse>> UpdateSendingDomain(this Client @this, string domain,
            UpdateSendingDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateSendingDomainResponse>);
        }

        public static Task<Either<ErrorResponse, VerifySendingDomainResponse>> VerifySendingDomain(this Client @this, string domain,
            VerifySendingDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}/verify";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<VerifySendingDomainResponse>);
        }

        private static string ToQueryString(SendingDomainsFilter filter)
        {
            var collection = new NameValueCollection();
            if (filter.OwnershipVerified != null)
            {
                collection.Add("ownership_verified", filter.OwnershipVerified.ToString());
            }

            if (filter.DkimStatus != null)
            {
                collection.Add("dkim_status", filter.DkimStatus.ToString());
            }

            if (filter.CnameStatus != null)
            {
                collection.Add("cname_status", filter.CnameStatus.ToString());
            }

            if (filter.MxStatus != null)
            {
                collection.Add("mx_status", filter.MxStatus.ToString());
            }

            if (filter.AbuseAtStatus != null)
            {
                collection.Add("abuse_at_status", filter.AbuseAtStatus.ToString());
            }

            if (filter.PostmasterAtStatus != null)
            {
                collection.Add("postmaster_at_status", filter.PostmasterAtStatus.ToString());
            }

            if (filter.ComplianceStatus != null)
            {
                collection.Add("compliance_status", filter.ComplianceStatus.ToString());
            }

            if (filter.IsDefaultBounceDomain != null)
            {
                collection.Add("is_default_bounce_domain", filter.IsDefaultBounceDomain.ToString());
            }

            return NameValueCollectionExtensions.ToQueryString(collection);
        }
    }
}