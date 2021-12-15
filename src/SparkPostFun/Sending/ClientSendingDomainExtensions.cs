using System.Collections.Specialized;
using LanguageExt;
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

        private static string ToQueryString(SendingDomainsFilter filter)
        {
            var queryString = new NameValueCollection();
            if (filter.OwnershipVerified != null)
            {
                queryString.Add("ownership_verified", filter.OwnershipVerified.ToString());
            }

            if (filter.DkimStatus != null)
            {
                queryString.Add("dkim_status", filter.DkimStatus.ToString());
            }

            if (filter.CnameStatus != null)
            {
                queryString.Add("cname_status", filter.CnameStatus.ToString());
            }

            if (filter.MxStatus != null)
            {
                queryString.Add("mx_status", filter.MxStatus.ToString());
            }

            if (filter.AbuseAtStatus != null)
            {
                queryString.Add("abuse_at_status", filter.AbuseAtStatus.ToString());
            }

            if (filter.PostmasterAtStatus != null)
            {
                queryString.Add("postmaster_at_status", filter.PostmasterAtStatus.ToString());
            }

            if (filter.ComplianceStatus != null)
            {
                queryString.Add("compliance_status", filter.ComplianceStatus.ToString());
            }

            if (filter.IsDefaultBounceDomain != null)
            {
                queryString.Add("is_default_bounce_domain", filter.IsDefaultBounceDomain.ToString());
            }

            return queryString.ToString();
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
    }
}