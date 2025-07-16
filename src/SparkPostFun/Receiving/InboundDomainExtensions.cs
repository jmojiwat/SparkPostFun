using System.Threading.Tasks;
using LanguageExt;
using static LanguageExt.Prelude;

namespace SparkPostFun.Receiving;

public static class InboundDomainExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> CreateInboundDomain(
        CreateInboundDomainRequest request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inbound-domains"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ClientExtensions.ToResponse<Unit>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveInboundDomainResponse>>>
        RetrieveInboundDomain(string domain)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inbound-domains/{domain}"
            select env.Client.Get<RetrieveInboundDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteInboundDomain(string domain)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inbound-domains/{domain}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListInboundDomainsResponse>>>
        ListInboundDomains()
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/inbound-domains"
            select env.Client.Get<ListInboundDomainsResponse>(requestUrl);
    }
}