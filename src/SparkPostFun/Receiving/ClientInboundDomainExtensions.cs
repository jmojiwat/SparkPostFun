using LanguageExt;

namespace SparkPostFun.Receiving
{
    public static class ClientInboundDomainExtensions
    {
 
        public static Task<Either<ErrorResponse, Unit>> CreateInboundDomain(this Client @this, CreateInboundDomain request)
        {
            var requestUrl = $"/api/{@this.Version}/inbound-domains";
            return @this.Post(requestUrl, request)
                .MapAsync(ClientExtensions.ToResponse<Unit>);
        }

        public static Task<Either<ErrorResponse, RetrieveInboundDomainResponse>> RetrieveInboundDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/inbound-domains/{domain}";
            return @this.Get<RetrieveInboundDomainResponse>(requestUrl);
        }

        public static Task<Either<ErrorResponse, Unit>> DeleteInboundDomain(this Client @this, string domain)
        {
            var requestUrl = $"/api/{@this.Version}/inbound-domains/{domain}";
            return @this.Delete(requestUrl);
        }

        public static Task<Either<ErrorResponse, ListInboundDomainsResponse>> ListInboundDomains(this Client @this)
        {
            var requestUrl = $"/api/{@this.Version}/inbound-domains";
            return @this.Get<ListInboundDomainsResponse>(requestUrl);

        }
    }
}