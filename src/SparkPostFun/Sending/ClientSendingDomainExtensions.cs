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

        public static Task<Either<ErrorResponse, VerifySendingDomainResponse>> VerifySendingDomain(this Client @this, string domain, VerifySendingDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}/verify";
            return @this.Post(requestUrl, request)
                .MapAsync(ToResponse<VerifySendingDomainResponse>);
        }

        public static Task<Either<ErrorResponse, RetrieveSendingDomainResponse>> RetrieveSendingDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Get<RetrieveSendingDomainResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, UpdateSendingDomainResponse>> UpdateSendingDomain(this Client @this, string domain, UpdateSendingDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateSendingDomainResponse>);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteSendingDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/sending-domains/{domain}";
            return @this.Delete(requestUrl);

        }

        public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListSendingDomains(this Client @this) => 
            ListSendingDomains(@this, null, null, null, null, null, null, null, null);

        public static Task<Either<ErrorResponse, ListSendingDomainsResponse>> ListSendingDomains(this Client @this, bool? ownershipVerified, DkimStatus? dkimStatus, CnameStatus? cnameStatus, MxStatus? mxStatus, AbuseAtStatus? abuseAtStatus, PostmasterAtStatus? postmasterAtStatus, ComplianceStatus? complianceStatus, bool? isDefaultBounceDomain)
        {
            var nameValue = new NameValueCollection();
            if(ownershipVerified != null)
            {
                nameValue.Add("ownership_verified", ownershipVerified.ToString());
            }
            if(dkimStatus != null)
            {
                nameValue.Add("dkim_status", dkimStatus.ToString());
            }
            if(cnameStatus != null)
            {
                nameValue.Add("cname_status", cnameStatus.ToString());
            }
            if(mxStatus != null)
            {
                nameValue.Add("mx_status", mxStatus.ToString());
            }
            if(abuseAtStatus != null)
            {
                nameValue.Add("abuse_at_status", abuseAtStatus.ToString());
            }
            if(postmasterAtStatus != null)
            {
                nameValue.Add("postmaster_at_status", postmasterAtStatus.ToString());
            }
            if(complianceStatus != null)
            {
                nameValue.Add("compliance_status", complianceStatus.ToString());
            }
            if(isDefaultBounceDomain != null)
            {
                nameValue.Add("is_default_bounce_domain", isDefaultBounceDomain.ToString());
            }

            var requestUrl = $"/api/{@this.Version}/sending-domains?{nameValue}";
            return @this.Get<ListSendingDomainsResponse>(requestUrl);
        }
    }
}