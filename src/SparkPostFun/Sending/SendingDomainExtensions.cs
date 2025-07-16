using System.Collections.Specialized;
using System.Threading.Tasks;
using LanguageExt;
using static SparkPostFun.ClientExtensions;
using static LanguageExt.Prelude;
using static SparkPostFun.Infrastructure.NameValueCollectionExtensions;
namespace SparkPostFun.Sending;

public static class SendingDomainExtensions
{
    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, CreateSendingDomainResponse>>>
        CreateSendingDomain(CreateSendingDomain request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<CreateSendingDomainResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, Unit>>> DeleteSendingDomain(string domain)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains/{domain}"
            select env.Client.Delete(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSendingDomainsResponse>>>
        ListSendingDomains()
    {
        return ListSendingDomains(new SendingDomainsFilter());
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, ListSendingDomainsResponse>>>
        ListSendingDomains(SendingDomainsFilter filter)
    {
        var queryString = ToQueryString(filter);

        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains?{queryString}"
            select env.Client.Get<ListSendingDomainsResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, RetrieveSendingDomainResponse>>>
        RetrieveSendingDomain(string domain)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains/{domain}"
            select env.Client.Get<RetrieveSendingDomainResponse>(requestUrl);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, UpdateSendingDomainResponse>>>
        UpdateSendingDomain(string domain,
            UpdateSendingDomain request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains/{domain}"
            select env.Client.Put(requestUrl, request)
                .MapAsync(ToResponse<UpdateSendingDomainResponse>);
    }

    public static Reader<SparkPostEnvironment, Task<Either<ErrorResponse, VerifySendingDomainResponse>>>
        VerifySendingDomain(string domain,
            VerifySendingDomain request)
    {
        return
            from env in ask<SparkPostEnvironment>()
            let requestUrl = $"/api/{env.Version}/sending-domains/{domain}/verify"
            select env.Client.Post(requestUrl, request)
                .MapAsync(ToResponse<VerifySendingDomainResponse>);
    }

    private static string ToQueryString(SendingDomainsFilter filter)
    {
        var collection = new NameValueCollection();

        AddIfNotNull("ownership_verified", filter.OwnershipVerified, collection);
        AddIfNotNull("dkim_status", filter.DkimStatus, collection);
        AddIfNotNull("cname_status", filter.CnameStatus, collection);
        AddIfNotNull("mx_status", filter.MxStatus, collection);
        AddIfNotNull("abuse_at_status", filter.AbuseAtStatus, collection);
        AddIfNotNull("postmaster_at_status", filter.PostmasterAtStatus, collection);
        AddIfNotNull("compliance_status", filter.ComplianceStatus, collection);
        AddIfNotNull("is_default_bounce_domain", filter.IsDefaultBounceDomain, collection);

        return NameValueCollectionToQueryString(collection);
    }
}